using System.Text;
using User.Application.Interfaces.Authentication;
using User.Domain.Entities;

namespace User.Infrastructure.Authentication
{
    public class SimpleTokenGenerator : ITokenGenerator
    {
        public string GenerateAccessToken(UserModel user)
        {
            var payload = $"{user.Id}|{user.Email}|{DateTime.UtcNow:o}";
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(payload));
        }

        public string GenerateRefreshToken() => Guid.NewGuid().ToString("N");
    }
}
