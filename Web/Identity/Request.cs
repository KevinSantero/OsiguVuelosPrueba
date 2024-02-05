namespace Web.Identity
{
    public class AuthRequest
    {
        public string? NombreUsuario { get; set; }
        public string? Contrasena { get; set; }
    }


    public class Error
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class ResultResponse<T>
    {
        public T value { get; set; }
        public bool isSuccess { get; set; }
        public bool isFailure { get; set; }
        public Error error { get; set; }
    }


    public record AuthResponse
    {
        public string? UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; }
        public string? Value { get; set; }
    }

    public class RegisterRequest
    {
        public string? FullName { get; set; }
        public string? Username { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string[]? Roles { get; set; }
    }
}
