using Application.Interfaces;
using Domain;

namespace Application.Commands.MembershipCommands
{
    public interface IChangeMembership : ICommand<Membership>
    {
    }
}
