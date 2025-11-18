using KnowTask.Core.Interfaces.CQRS;
using User.Application.Interfaces.Authentication;
using User.Application.Interfaces.Persistence;
using User.Domain.Entities;
using User.Domain.Interfaces;
using static User.Application.DTOs.AuthModel;

namespace User.Application.CQRS.Auth.Commands.RegisterUser
{
    public class RegisterUserHandler(IUserRepository userRepository, ITokenGenerator tokenGenerator, IPasswordHasher passwordHasher)
        : ICommandHandler<RegisterUserCommand, AuthResponse>
    {
        public async Task<AuthResponse> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var existingUser = await userRepository.GetByEmailAsync(command.RegisterRequest.Email);
            if (existingUser != null) throw new InvalidOperationException("Email already exists");

            var user = new UserModel(command.RegisterRequest.Email, command.RegisterRequest.FullName);
            user.SetPassword(command.RegisterRequest.Password, passwordHasher);
            
            await userRepository.AddAsync(user);
            
            var accessToken = tokenGenerator.GenerateAccessToken(user);
            var refreshToken = tokenGenerator.GenerateRefreshToken();

            return new AuthResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Email = user.Email,
                FullName = user.FullName
            };
        }
    }
}
