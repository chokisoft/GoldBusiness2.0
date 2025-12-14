namespace GoldBusinessOne.Services
{
    public class AuthResult
    {
        public bool Success { get; }
        public string? ErrorMessage { get; }
        public int StatusCode { get; }

        public AuthResult(bool success, string? errorMessage = null, int statusCode = 0)
        {
            Success = success;
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }
    }
}