using Application.Dto.Book;
using Application.Interfaces;
using Domain;

namespace Application.Commands.Books
{
    public interface IChangeBookCommand : ICommand<Book>
    {
    }
}
