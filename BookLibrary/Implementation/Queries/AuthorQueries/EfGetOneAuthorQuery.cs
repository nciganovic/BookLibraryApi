using Application.Dto.Author;
using Application.Queries.Authors;
using AutoMapper;
using DataAccess;
using Domain;
using System;

namespace Implementation.Queries.AuthorQueries
{
    public class EfGetOneAuthorQuery : BaseQuery<Author>, IGetOneAuthorQuery
    {
        private IMapper _mapper;

        public EfGetOneAuthorQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 74;

        public string Name => "Get one author";

        public AuthorResultDto Execute(int search)
        {
            Author author = context.Authors.Find(search);
            if (author?.DeletedAt != null)
                return null;
            return _mapper.Map<Author, AuthorResultDto>(author);
        }
    }
}
