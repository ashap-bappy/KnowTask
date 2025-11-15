using MediatR;
using User.Application.Interfaces.Authentication;
using User.Application.Interfaces.Persistence;
using static User.Application.DTOs.AuthModel;

namespace User.Application.CQRS.Auth.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<MediatRCommandAdapter<AuthResponse>, AuthResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;
        public Task<AuthResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
