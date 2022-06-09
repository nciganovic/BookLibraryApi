using Application.Dto.Author;
using Application.Queries.Authors;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Implementation.Queries.AuthorQueries
{
    public class EfGetAuthorsQuery : BaseQuery<Author>, IGetAuthorsQuery
    {
        private IMapper _mapper;

        public EfGetAuthorsQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 75;

        public string Name => "Get Authors";

        public IEnumerable<AuthorResultDto> Execute(AuthorSearch search)
        {
            var query = this.context.Authors.AsQueryable();

            if (search.FirstName != null)
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));

            if (search.LastName != null)
                query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));

            if (search.Bio != null)
                query = query.Where(x => x.Bio.ToLower().Contains(search.Bio.ToLower()));

            BasicFilter(ref query, search);

            return query.OrderBy(x => x.LastName).Select(x => _mapper.Map<Author, AuthorResultDto>(x)).ToList();
        }
    }
}
