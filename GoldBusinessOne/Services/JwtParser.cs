using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace GoldBusinessOne.Services
{
    public static class JwtParser
    {
        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            if (string.IsNullOrWhiteSpace(jwt)) yield break;
            var parts = jwt.Split('.');
            if (parts.Length < 2) yield break;

            var payload = parts[1];
            byte[] jsonBytes = ParseBase64WithoutPadding(payload);
            using var doc = JsonDocument.Parse(jsonBytes);
            foreach (var prop in doc.RootElement.EnumerateObject())
            {
                if (prop.Value.ValueKind == JsonValueKind.Array)
                {
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        yield return new Claim(prop.Name, item.ToString());
                    }
                }
                else
                {
                    yield return new Claim(prop.Name, prop.Value.ToString() ?? string.Empty);
                }
            }
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            base64 = base64.Replace('-', '+').Replace('_', '/');
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}