using User.Domain.Entities;

namespace User.Application.Interfaces.Authentication
{
    public interface ITokenGenerator
    {
        string GenerateAccessToken(UserModel user);
        string GenerateRefreshToken();
    }
}
