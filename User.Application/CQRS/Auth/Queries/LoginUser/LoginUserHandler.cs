using MediatR;
using static User.Application.DTOs.AuthModel;

namespace User.Application.CQRS.Auth.Queries.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserQuery, AuthResponse>
    {
        public Task<AuthResponse> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
