using Application.Dto.Book;
using Application.Interfaces;

namespace Application.Queries.Books
{
    public interface IGetOneBookQuery : IQuery<int, BookResultDto>
    {
    }
}
