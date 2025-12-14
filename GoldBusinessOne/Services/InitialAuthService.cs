using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace GoldBusinessOne.Services
{
    public class InitialAuthService
    {
        private readonly NavigationManager _navigation;
        private readonly AuthenticationStateProvider _authProvider;

        public InitialAuthService(NavigationManager navigation, AuthenticationStateProvider authProvider)
        {
            _navigation = navigation;
            _authProvider = authProvider;
        }

        public async Task InitializeAsync()
        {
            // Verificar si hay token en localStorage
            var authState = await _authProvider.GetAuthenticationStateAsync();

            // Si no está autenticado Y no está en la página de login, redirigir
            if (!authState.User.Identity?.IsAuthenticated ?? true)
            {
                var currentUri = new Uri(_navigation.Uri);
                if (!currentUri.AbsolutePath.Contains("/login"))
                {
                    var returnUrl = _navigation.ToBaseRelativePath(_navigation.Uri);
                    _navigation.NavigateTo($"/login?returnUrl={Uri.EscapeDataString(returnUrl)}", true);
                }
            }
        }
    }
}