using Application.Interfaces;
using Domain;

namespace Application.Commands.Roles
{
    public interface IChangeRoleCommand : ICommand<Role>
    {
    }
}
