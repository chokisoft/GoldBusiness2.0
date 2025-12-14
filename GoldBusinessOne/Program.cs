using GoldBusinessOne.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Security.Claims;

namespace GoldBusinessOne
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Named HttpClient for API calls
            builder.Services.AddTransient<TokenHttpMessageHandler>();
            builder.Services.AddHttpClient("Api", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7289/");
                // Opcional: Configurar timeout
                client.Timeout = TimeSpan.FromSeconds(30);
                // Opcional: Configurar headers por defecto
                client.DefaultRequestHeaders.Add("X-Application-Name", "GoldBusinessOne");
                client.DefaultRequestHeaders.Add("X-Application-Version", "1.0.0");
            })
            .AddHttpMessageHandler<TokenHttpMessageHandler>();

            // Default HttpClient (usa el mismo configurado arriba)
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Api"));

            // Auth services
            builder.Services.AddAuthorizationCore(options =>
            {
                // Opcional: Definir políticas personalizadas
                options.AddPolicy("AdminOnly", policy =>
                    policy.RequireClaim(ClaimTypes.Role, "Admin"));

                options.AddPolicy("ManagerOrAdmin", policy =>
                    policy.RequireAssertion(context =>
                        context.User.HasClaim(c =>
                            c.Type == ClaimTypes.Role &&
                            (c.Value == "Admin" || c.Value == "Manager"))));

                // Política basada en permisos de nivel
                options.AddPolicy("Level3Access", policy =>
                    policy.RequireAssertion(context =>
                        context.User.HasClaim("perm.data", "level3") ||
                        context.User.HasClaim("perm.data", "level4") ||
                        context.User.IsInRole("Admin")));
            });

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            // En Program.cs, después de los servicios de auth
            builder.Services.AddScoped<InitialAuthService>();

            // Opcional: Servicio para acceder fácilmente a claims/permissions
            builder.Services.AddScoped<IPermissionService, PermissionService>();

            // Opcional: Servicio para manejar redirecciones de auth
            builder.Services.AddScoped<AuthRedirectService>();

            await builder.Build().RunAsync();
        }
    }
}