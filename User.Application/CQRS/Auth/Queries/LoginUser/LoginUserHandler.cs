using KnowTask.Core.Interfaces.CQRS;
using User.Application.Interfaces.Authentication;
using User.Application.Interfaces.Persistence;
using User.Domain.Interfaces;
using static User.Application.DTOs.AuthModel;

namespace User.Application.CQRS.Auth.Queries.LoginUser
{
    public class LoginUserHandler(IUserRepository userRepository, ITokenGenerator tokenGenerator, IPasswordHasher passwordHasher) : IQueryHandler<LoginUserQuery, AuthResponse>
    {
        public async Task<AuthResponse> Handle(LoginUserQuery query, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByEmailAsync(query.LoginRequest.Email);
            if (user == null || !user.VerifyPassword(query.LoginRequest.Password, passwordHasher))
                throw new UnauthorizedAccessException("Invalid credentials");

            var access = tokenGenerator.GenerateAccessToken(user);
            var refresh = tokenGenerator.GenerateRefreshToken();

            return new AuthResponse
            {
                AccessToken = access,
                RefreshToken = refresh,
                Email = user.Email,
                FullName = user.FullName
            };
        }
    }
}
