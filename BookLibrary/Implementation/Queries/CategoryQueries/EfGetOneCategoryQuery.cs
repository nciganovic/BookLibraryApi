using Application.Dto.Category;
using Application.Queries.Categories;
using AutoMapper;
using DataAccess;
using Domain;
using System;

namespace Implementation.Queries.CategoryQueries
{
    public class EfGetOneCategoryQuery : BaseQuery<Category>, IGetOneCategoryQuery
    {
        private IMapper _mapper;

        public EfGetOneCategoryQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 64;

        public string Name => "Get one category";

        public CategoryResultDto Execute(int search)
        {
            Category category = context.Categories.Find(search);
            if (category?.DeletedAt != null)
                return null;
            return _mapper.Map<Category, CategoryResultDto>(category);
        }
    }
}
