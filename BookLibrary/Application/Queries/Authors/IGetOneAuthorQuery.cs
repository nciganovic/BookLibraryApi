using Application.Dto.Author;
using Application.Interfaces;

namespace Application.Queries.Authors
{
    public interface IGetOneAuthorQuery : IQuery<int, AuthorResultDto>
    {
    }
}
