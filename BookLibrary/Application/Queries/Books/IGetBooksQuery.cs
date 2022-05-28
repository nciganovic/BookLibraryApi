using Application.Dto.Book;
using Application.Interfaces;
using Application.Searches;
using System.Collections.Generic;

namespace Application.Queries.Books
{
    public interface IGetBooksQuery : IQuery<BookSearch, IEnumerable<BookResultDto>>
    {
        
    }
}
