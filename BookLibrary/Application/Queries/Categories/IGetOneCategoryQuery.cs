using Application.Dto.Category;
using Application.Interfaces;

namespace Application.Queries.Categories
{
    public interface IGetOneCategoryQuery : IQuery<int, CategoryResultDto>
    {
    }
}
