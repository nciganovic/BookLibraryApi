using Application.Dto.Book;
using Application.Interfaces;

namespace Application.Commands.Books
{
    public interface IChangeBookAuthorsCommand : ICommand<ChangeBookAuthorsDto>
    {
    }
}
