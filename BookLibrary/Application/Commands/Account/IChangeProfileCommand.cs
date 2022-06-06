using Application.Interfaces;
using Domain;

namespace Application.Commands.Account
{
    public interface IChangeProfileCommand : ICommand<User>
    {
    }
}
