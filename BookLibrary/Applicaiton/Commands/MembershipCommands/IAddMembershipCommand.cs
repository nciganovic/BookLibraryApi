using Application.Interfaces;
using Domain;

namespace Application.Commands.MembershipCommands
{
    public interface IAddMembershipCommand : ICommand<Membership>
    {
    }
}
