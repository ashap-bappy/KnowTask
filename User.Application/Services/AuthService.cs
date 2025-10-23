using Microsoft.Extensions.Configuration;
using System.CodeDom.Compiler;
using User.Application.Contracts;
using User.Domain.Entities;
using static User.Application.DTOs.AuthModel;

namespace User.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var existing = _userRepository.GetByEmailAsync(request.Email);

            if (existing != null)
            {
                throw new Exception("Email already registered.");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = new UserModel(request.Email, passwordHash, request.FullName);

            _userRepository.AddAsync(user);
            return GenerateTokens(user);
        }

        private Task<AuthResponse> GenerateTokens(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
