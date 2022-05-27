using Application.Dto.Category;
using Application.Queries.Categories;
using AutoMapper;
using DataAccess;
using Domain;
using System;

namespace Implementation.Queries.CategoriesQueries
{
    public class EfGetOneCategoriesQuery : BaseQuery<Category>, IGetOneCategoryQuery
    {
        private IMapper _mapper;

        public EfGetOneCategoriesQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 64;

        public string Name => "Get one category";

        public CategoryResultDto Execute(int search)
        {


            throw new Exception();
        }
    }
}
