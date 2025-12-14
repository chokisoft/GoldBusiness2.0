using System.Security.Claims;

namespace GoldBusinessOne.Services
{
    public interface IAuthService
    {
        // Evento para notificar cambios en el estado de autenticación
        event Func<Task>? AuthenticationStateChanged;

        // Método para login (devuelve AuthResult)
        Task<AuthResult> LoginAsync(string userName, string password);

        // Método para logout
        Task LogoutAsync();

        // Obtener token actual
        Task<string?> GetTokenAsync();

        // Obtener ClaimsPrincipal para el usuario actual
        Task<ClaimsPrincipal> GetClaimsPrincipalAsync();

        // Métodos adicionales útiles (opcionales)
        Task<bool> IsAuthenticatedAsync();
        Task<bool> RefreshTokenIfNeeded();
    }
}