using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.JSInterop;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace GoldBusinessOne.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _js;
        private const string TokenKey = "authToken";

        public event Func<Task>? AuthenticationStateChanged;

        public AuthService(HttpClient http, IJSRuntime js)
        {
            _http = http;
            _js = js;
        }

        public async Task<AuthResult> LoginAsync(string userName, string password)
        {
            try
            {
                var resp = await _http.PostAsJsonAsync("api/auth/login", new
                {
                    UserName = userName,
                    Password = password
                });

                if (!resp.IsSuccessStatusCode)
                {
                    var error = await resp.Content.ReadAsStringAsync();
                    return new AuthResult(false, error, (int)resp.StatusCode);
                }

                var json = await resp.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);

                string? token = null;
                if (doc.RootElement.TryGetProperty("token", out var t1))
                    token = t1.GetString();
                else if (doc.RootElement.TryGetProperty("Token", out var t2))
                    token = t2.GetString();

                if (string.IsNullOrEmpty(token))
                    return new AuthResult(false, "No se recibió token del servidor");

                await _js.InvokeVoidAsync("localStorage.setItem", TokenKey, token);

                // Notificar a los suscriptores (CustomAuthStateProvider)
                if (AuthenticationStateChanged != null)
                {
                    await AuthenticationStateChanged.Invoke();
                }

                return new AuthResult(true);
            }
            catch (HttpRequestException ex)
            {
                return new AuthResult(false, $"Error de conexión: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new AuthResult(false, $"Error: {ex.Message}");
            }
        }

        public async Task LogoutAsync()
        {
            try
            {
                // Remover token del localStorage
                await _js.InvokeVoidAsync("localStorage.removeItem", TokenKey);

                // Opcional: Llamar al endpoint de logout en la API
                // await _http.PostAsync("api/auth/logout", null);

                // Notificar a los suscriptores (CustomAuthStateProvider)
                if (AuthenticationStateChanged != null)
                {
                    await AuthenticationStateChanged.Invoke();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error durante logout: {ex.Message}");
                // Si hay error, igual intentamos limpiar el token localmente
                try
                {
                    await _js.InvokeVoidAsync("localStorage.removeItem", TokenKey);
                }
                catch
                {
                    // Ignorar errores secundarios
                }
            }
        }

        public async Task<string?> GetTokenAsync()
        {
            try
            {
                return await _js.InvokeAsync<string?>("localStorage.getItem", TokenKey);
            }
            catch
            {
                return null;
            }
        }

        public async Task<ClaimsPrincipal> GetClaimsPrincipalAsync()
        {
            try
            {
                var token = await GetTokenAsync();

                if (string.IsNullOrEmpty(token))
                {
                    // Usuario no autenticado
                    return new ClaimsPrincipal(new ClaimsIdentity());
                }

                // Validar y parsear el token JWT
                var handler = new JwtSecurityTokenHandler();

                if (!handler.CanReadToken(token))
                {
                    // Token inválido - limpiar
                    await LogoutAsync();
                    return new ClaimsPrincipal(new ClaimsIdentity());
                }

                var jwtToken = handler.ReadJwtToken(token);

                // Verificar expiración
                if (jwtToken.ValidTo < DateTime.UtcNow)
                {
                    // Token expirado - limpiar
                    await LogoutAsync();
                    return new ClaimsPrincipal(new ClaimsIdentity());
                }

                // Crear claims identity
                var claims = new List<Claim>();

                // Agregar claims del token
                foreach (var claim in jwtToken.Claims)
                {
                    claims.Add(claim);
                }

                // Agregar claim de autenticación
                claims.Add(new Claim(ClaimTypes.AuthenticationMethod, "Bearer"));

                var identity = new ClaimsIdentity(claims, "jwt");
                return new ClaimsPrincipal(identity);
            }
            catch (Exception)
            {
                // En caso de cualquier error, retornar no autenticado
                return new ClaimsPrincipal(new ClaimsIdentity());
            }
        }

        // Método adicional útil
        public async Task<bool> IsAuthenticatedAsync()
        {
            var token = await GetTokenAsync();
            return !string.IsNullOrEmpty(token);
        }

        // Método para refrescar token si es necesario
        public async Task<bool> RefreshTokenIfNeeded()
        {
            try
            {
                var token = await GetTokenAsync();
                if (string.IsNullOrEmpty(token))
                    return false;

                var handler = new JwtSecurityTokenHandler();
                if (!handler.CanReadToken(token))
                    return false;

                var jwtToken = handler.ReadJwtToken(token);
                var timeRemaining = jwtToken.ValidTo - DateTime.UtcNow;

                // Si el token expira en menos de 5 minutos, intentar refrescar
                if (timeRemaining.TotalMinutes < 5)
                {
                    // Llamar al endpoint de refresh token
                    var response = await _http.PostAsync("api/auth/refresh-token", null);
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        using var doc = JsonDocument.Parse(json);

                        string? newToken = null;
                        if (doc.RootElement.TryGetProperty("token", out var t1))
                            newToken = t1.GetString();
                        else if (doc.RootElement.TryGetProperty("Token", out var t2))
                            newToken = t2.GetString();

                        if (!string.IsNullOrEmpty(newToken))
                        {
                            await _js.InvokeVoidAsync("localStorage.setItem", TokenKey, newToken);

                            if (AuthenticationStateChanged != null)
                            {
                                await AuthenticationStateChanged.Invoke();
                            }

                            return true;
                        }
                    }
                    return false;
                }

                return true; // Token todavía válido
            }
            catch
            {
                return false;
            }
        }
    }
}