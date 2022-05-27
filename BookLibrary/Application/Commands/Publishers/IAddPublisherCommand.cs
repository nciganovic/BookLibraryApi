using Application.Interfaces;
using Domain;

namespace Application.Commands.Publishers
{
    public interface IAddPublisherCommand : ICommand<Publisher>
    {
    }
}
