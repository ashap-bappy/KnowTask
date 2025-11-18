using KnowTask.Core.Interfaces.CQRS;
using static User.Application.DTOs.AuthModel;

namespace User.Application.CQRS.Auth.Commands.RegisterUser
{
    public abstract record RegisterUserCommand(RegisterRequest RegisterRequest) : ICommand<AuthResponse>
    {
    }
}
