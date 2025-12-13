using APIGoldBusiness.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Configuración de la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// 🔹 Configuración de EF Core con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// 🔹 Configuración de Swagger/OpenAPI
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "API Gold Business",
        Version = "v2.00",
        Description = "API para la gestión de Gold Business",
        Contact = new OpenApiContact
        {
            Name = "Equipo de Desarrollo",
            Email = "chokisoft@gmail.com",
            Url = new Uri("https://midominio.com")
        },
        License = new OpenApiLicense
        {
            Name = "Chokisoft Development Software",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });
});

// 🔹 Controladores
builder.Services.AddControllers();

// 🔹 Configuración de CORS: permitir cualquier origen, método y encabezado
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// 🔹 Configuración de Kestrel para escuchar en el puerto 7289 con HTTPS
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(7289, listenOptions =>
    {
        listenOptions.UseHttps(); // mantiene HTTPS
    });
});

// 🔹 Endpoints API Explorer (necesario para Swagger)
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// 🔹 Configuración del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Apuntar a la versión correcta de Swagger
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "API Gold Business - Versión 2.00");
    });
}

// 🔹 Activar CORS antes de Authorization
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

// 🔹 Mapear controladores
app.MapControllers();

// 🔹 Ejecutar la aplicación
app.Run();