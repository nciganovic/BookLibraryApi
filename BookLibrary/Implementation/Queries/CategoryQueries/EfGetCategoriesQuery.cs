using Application.Dto.Category;
using Application.Queries.Categories;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Implementation.Queries.CategoryQueries
{
    public class EfGetCategoriesQuery : BaseQuery<Category>, IGetCategoriesQuery
    {
        private IMapper _mapper;

        public EfGetCategoriesQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 65;

        public string Name => "Get categories";

        public IEnumerable<CategoryResultDto> Execute(CategorySearch search)
        {
            var query = this.context.Categories.AsQueryable();

            BasicFilter(ref query, search);

            if (search.Name != null)
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

            return query.OrderBy(x => x.Name).Select(x => _mapper.Map<Category, CategoryResultDto>(x)).ToList();
        }
    }
}
