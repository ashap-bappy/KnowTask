namespace User.Application.DTOs
{
    public abstract class AuthModel
    {
        public record RegisterRequest
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
            public required string FullName { get; set; }
        }

        public record LoginRequest
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
        }

        public record AuthResponse
        {
            public required string AccessToken { get; set; }
            public required string RefreshToken { get; set; }
            public required string Email { get; set; }
            public required string FullName { get; set; }
        }
    }
}
