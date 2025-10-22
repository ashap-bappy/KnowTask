namespace User.Application.DTOs
{
    public class AuthModel
    {
        public class RegisterRequest
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
            public required string FullName { get; set; }
        }

        public class LoginRequest
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
        }

        public class AuthResponse
        {
            public required string AccessToken { get; set; }
            public required string RefreshToken { get; set; }
        }
    }
}
