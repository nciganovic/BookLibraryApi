using Application.Dto.Category;
using Application.Interfaces;
using Application.Searches;
using System.Collections.Generic;

namespace Application.Queries.Categories
{
    public interface IGetCategoriesQuery : IQuery<CategorySearch, IEnumerable<CategoryResultDto>>
    {
    }
}
