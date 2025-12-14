using GoldBusiness.Shared;
using GoldBusinessOne.Services.GrupoCuentaServices;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GoldBusinessOne.Services
{
    public class GrupoCuentaService : IGrupoCuentaService
    {
        private readonly HttpClient _httpClient;

        // IMPORTANTE: Verifica la URL correcta de tu API
        private const string BaseUrl = "api/GrupoCuenta"; // O "api/grupocuentas"

        public GrupoCuentaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GrupoCuenta>> GetAllAsync()
        {
            try
            {
                Console.WriteLine($"Llamando a API: {BaseUrl}");
                var result = await _httpClient.GetFromJsonAsync<List<GrupoCuenta>>(BaseUrl);
                Console.WriteLine($"Datos recibidos: {result?.Count ?? 0} registros");
                return result ?? new List<GrupoCuenta>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error HTTP: {ex.Message}");
                if (ex.StatusCode.HasValue)
                {
                    Console.WriteLine($"Código de estado: {ex.StatusCode}");
                }
                return new List<GrupoCuenta>();
            }
        }

        public async Task<GrupoCuenta> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<GrupoCuenta>($"{BaseUrl}/{id}");
        }

        public async Task CreateAsync(GrupoCuenta grupoCuenta)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, grupoCuenta);

            // Verificar si hubo error
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error al crear: {response.StatusCode} - {errorContent}");
                throw new HttpRequestException($"Error {response.StatusCode}: {errorContent}");
            }

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(GrupoCuenta grupoCuenta)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{grupoCuenta.Id}", grupoCuenta);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error al actualizar: {response.StatusCode} - {errorContent}");
                throw new HttpRequestException($"Error {response.StatusCode}: {errorContent}");
            }

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error al eliminar: {response.StatusCode} - {errorContent}");
                throw new HttpRequestException($"Error {response.StatusCode}: {errorContent}");
            }

            response.EnsureSuccessStatusCode();
        }
    }
}