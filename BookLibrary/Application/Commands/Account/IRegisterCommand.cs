using Application.Interfaces;
using Domain;

namespace Application.Commands.Account
{
    public interface IRegisterCommand : ICommand<User>
    {
    }
}
