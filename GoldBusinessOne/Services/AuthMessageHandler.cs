using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

public class AuthMessageHandler : DelegatingHandler
{
    private readonly NavigationManager _navigation;

    public AuthMessageHandler(NavigationManager navigation)
    {
        _navigation = navigation;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
        {
            // Optionally attempt token refresh here (call a refresh service).
            // If refresh fails or not supported, redirect to login with returnUrl.
            var returnUrl = _navigation.ToBaseRelativePath(_navigation.Uri);
            _navigation.NavigateTo($"/login?returnUrl={Uri.EscapeDataString("/" + returnUrl)}", true);
        }

        return response;
    }
}