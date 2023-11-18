using ErrorOr;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public record CreateUserCommand(
        string Email,
        string Password
        ) : IRequest<ErrorOr<Guid>>
    {
    }
}
