using Application.Interfaces;
using Domain;

namespace Application.Commands.Authors
{
    public interface IChangeAuthorCommand : ICommand<Author>
    {
    }
}
