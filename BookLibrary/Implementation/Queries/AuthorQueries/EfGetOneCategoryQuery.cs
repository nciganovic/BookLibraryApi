using Application.Dto.Author;
using Application.Queries.Authors;
using AutoMapper;
using DataAccess;
using Domain;
using System;

namespace Implementation.Queries.AuthorsQueries
{
    public class EfGetOneAuthorsQuery : BaseQuery<Author>, IGetOneAuthorQuery
    {
        private IMapper _mapper;

        public EfGetOneAuthorsQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 74;

        public string Name => "Get one author";

        public AuthorResultDto Execute(int search)
        {


            throw new Exception();
        }
    }
}
