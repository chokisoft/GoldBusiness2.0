using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace GoldBusinessOne.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider, IDisposable
    {
        private readonly IAuthService _authService;
        private bool _disposed;

        public CustomAuthStateProvider(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));

            // Suscribirse a las notificaciones de AuthService
            _authService.AuthenticationStateChanged += OnAuthStateChanged;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                // Obtener ClaimsPrincipal desde AuthService
                var principal = await _authService.GetClaimsPrincipalAsync();
                return new AuthenticationState(principal);
            }
            catch
            {
                // En caso de error, retornar no autenticado
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }

        private async Task OnAuthStateChanged()
        {
            // Notificar a Blazor que re-evalúe el estado de autenticación
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            if (_authService != null)
            {
                _authService.AuthenticationStateChanged -= OnAuthStateChanged;
            }
        }
    }
}