using Microsoft.AspNetCore.Components;

namespace GoldBusinessOne.Services
{
    public class AuthRedirectService
    {
        private readonly NavigationManager _navigation;
        private readonly IAuthService _authService;

        public AuthRedirectService(NavigationManager navigation, IAuthService authService)
        {
            _navigation = navigation;
            _authService = authService;
        }

        public async Task RedirectToLoginIfNotAuthenticated(string returnUrl = "")
        {
            var token = await _authService.GetTokenAsync();
            if (string.IsNullOrEmpty(token))
            {
                var relativeUri = _navigation.ToBaseRelativePath(_navigation.Uri);
                var targetReturnUrl = string.IsNullOrEmpty(returnUrl) ?
                    "/" + relativeUri : returnUrl;

                var encodedReturnUrl = Uri.EscapeDataString(targetReturnUrl);
                _navigation.NavigateTo($"/login?returnUrl={encodedReturnUrl}", true);
            }
        }

        public void RedirectToAccessDenied()
        {
            _navigation.NavigateTo("/access-denied", true);
        }

        public void RedirectToHome()
        {
            _navigation.NavigateTo("/", true);
        }
    }
}