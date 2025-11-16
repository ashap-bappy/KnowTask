using KnowTask.Core.CQRS;
using User.Application.Interfaces.Authentication;
using User.Application.Interfaces.Persistence;
using static User.Application.DTOs.AuthModel;

namespace User.Application.CQRS.Auth.Commands.RegisterUser
{
    public class RegisterUserHandler(IUserRepository userRepository, ITokenGenerator tokenGenerator)
        : ICommandHandler<RegisterUserCommand, AuthResponse>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ITokenGenerator _tokenGenerator = tokenGenerator;

        public Task<AuthResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
