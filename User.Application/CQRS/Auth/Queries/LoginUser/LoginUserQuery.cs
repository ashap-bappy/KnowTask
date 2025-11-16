using KnowTask.Core.CQRS;
using static User.Application.DTOs.AuthModel;

namespace User.Application.CQRS.Auth.Queries.LoginUser
{
    public abstract record LoginUserQuery(LoginRequest LoginRequest) : IQuery<AuthResponse>
    {
    }
}
