using Application.Interfaces;
using Domain;

namespace Application.Commands.MembershipCommands
{
    public interface IChangeMembershipCommand : ICommand<Membership>
    {
    }
}
