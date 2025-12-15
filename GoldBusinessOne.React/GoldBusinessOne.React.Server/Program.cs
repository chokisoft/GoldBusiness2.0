using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configurar proxy inverso
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

// Configurar CORS para desarrollo
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactClient", policy =>
    {
        policy.WithOrigins("https://localhost:5173") // Puerto de Vite
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Configurar HttpClient para redirigir API calls
builder.Services.AddHttpClient("GoldBusinessAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7289"); // Tu API principal
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

var app = builder.Build();

// Configurar pipeline
if (app.Environment.IsDevelopment())
{
    app.UseCors("ReactClient");
    app.UseDeveloperExceptionPage();
}

// Middleware para redirigir llamadas API a tu backend principal
app.Use(async (context, next) =>
{
    // Si es una llamada API (/api/*), redirigir al backend principal
    if (context.Request.Path.StartsWithSegments("/api"))
    {
        var httpClientFactory = context.RequestServices.GetRequiredService<IHttpClientFactory>();
        var httpClient = httpClientFactory.CreateClient("GoldBusinessAPI");

        // Construir la URL destino
        var targetPath = context.Request.Path.Value?.Replace("/api", "");
        var queryString = context.Request.QueryString.Value;
        var targetUrl = $"{targetPath}{queryString}";

        // Crear la solicitud proxy
        var requestMessage = new HttpRequestMessage();
        requestMessage.RequestUri = new Uri(targetUrl, UriKind.Relative);
        requestMessage.Method = new HttpMethod(context.Request.Method);

        // Copiar headers
        foreach (var header in context.Request.Headers)
        {
            if (!header.Key.Equals("Host", StringComparison.OrdinalIgnoreCase))
            {
                requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
            }
        }

        // Copiar cuerpo para POST/PUT
        if (context.Request.ContentLength > 0)
        {
            context.Request.EnableBuffering();
            var bodyStream = new StreamReader(context.Request.Body);
            var bodyContent = await bodyStream.ReadToEndAsync();
            context.Request.Body.Position = 0;

            if (!string.IsNullOrEmpty(bodyContent))
            {
                requestMessage.Content = new StringContent(bodyContent, Encoding.UTF8, "application/json");
            }
        }

        // Enviar la solicitud
        var response = await httpClient.SendAsync(requestMessage);

        // Devolver la respuesta al cliente React
        context.Response.StatusCode = (int)response.StatusCode;
        foreach (var header in response.Headers)
        {
            context.Response.Headers[header.Key] = header.Value.ToArray();
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        await context.Response.WriteAsync(responseContent);

        return;
    }

    // Si no es API, continuar con el pipeline normal
    await next();
});

// Para archivos estáticos en producción
if (!app.Environment.IsDevelopment())
{
    app.UseDefaultFiles();
    app.UseStaticFiles();

    app.MapFallbackToFile("index.html");
}

app.Run();