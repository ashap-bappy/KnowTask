using KnowTask.Core.CQRS;
using static User.Application.DTOs.AuthModel;

namespace User.Application.CQRS.Auth.Commands.RegisterUser
{
    public record RegisterUserCommand(RegisterRequest registerRequest) : ICommand<AuthResponse>
    {
    }
}
