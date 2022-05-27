using Application.Dto.Category;
using Application.Queries.Categories;
using Application.Searches;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;

namespace Implementation.Queries.CategoryQueries
{
    public class EfGetCategoriesQuery : BaseQuery<Category>, IGetCategoriesQuery
    {
        public EfGetCategoriesQuery(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 65;

        public string Name => "Get categories";

        public IEnumerable<CategoryResultDto> Execute(CategorySearch search)
        {
            var query = this.context.Categories.AsQueryable();

            BasicFilter(ref query, search);

            throw new NotImplementedException();
        }
    }
}
