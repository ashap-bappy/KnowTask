using KnowTask.Core.Interfaces.CQRS;
using static User.Application.DTOs.AuthModel;

namespace User.Application.CQRS.Auth.Commands.RegisterUser
{
    public record RegisterUserCommand(RegisterRequest RegisterRequest) : ICommand<AuthResponse>
    {
    }
}
