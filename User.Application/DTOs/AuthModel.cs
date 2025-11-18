namespace User.Application.DTOs
{
    public abstract class AuthModel
    {
        public abstract class RegisterRequest
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
            public required string FullName { get; set; }
        }

        public abstract class LoginRequest
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
        }

        public class AuthResponse
        {
            public required string AccessToken { get; set; }
            public required string RefreshToken { get; set; }
            public required string Email { get; set; }
            public required string FullName { get; set; }
        }
    }
}
