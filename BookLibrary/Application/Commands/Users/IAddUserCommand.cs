using Application.Interfaces;
using Domain;

namespace Application.Commands.Users
{
    public interface IAddUserCommand : ICommand<User>
    {
    }
}
