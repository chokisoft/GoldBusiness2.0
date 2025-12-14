using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.JSInterop;

namespace GoldBusinessOne.Services
{
    public class TokenHttpMessageHandler : DelegatingHandler
    {
        private readonly IJSRuntime _js;
        private const string TokenKey = "authToken";

        public TokenHttpMessageHandler(IJSRuntime js)
        {
            _js = js;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // Obtener token del localStorage
            var token = await _js.InvokeAsync<string?>("localStorage.getItem", TokenKey);

            if (!string.IsNullOrEmpty(token))
            {
                // Agregar token al header de autorización
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Enviar la petición
            return await base.SendAsync(request, cancellationToken);
        }
    }
}