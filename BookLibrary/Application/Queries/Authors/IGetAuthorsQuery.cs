using Application.Dto.Author;
using Application.Interfaces;
using Application.Searches;
using System.Collections.Generic;

namespace Application.Queries.Authors
{
    public interface IGetAuthorsQuery : IQuery<AuthorSearch, IEnumerable<AuthorResultDto>>
    {
    }
}
