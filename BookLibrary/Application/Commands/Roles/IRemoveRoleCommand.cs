using Application.Interfaces;
using Domain;

namespace Application.Commands.Roles
{
    public interface IRemoveRoleCommand : ICommand<int>
    {
    }
}
