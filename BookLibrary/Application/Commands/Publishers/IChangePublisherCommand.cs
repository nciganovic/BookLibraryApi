using Application.Interfaces;
using Domain;

namespace Application.Commands.Publishers
{
    public interface IChangePublisherCommand : ICommand<Publisher>
    {
    }
}
