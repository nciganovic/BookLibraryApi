using Application.Dto.Author;
using Application.Queries.Authors;
using Application.Searches;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;

namespace Implementation.Queries.AuthorQueries
{
    public class EfGetAuthorsQuery : BaseQuery<Author>, IGetAuthorsQuery
    {
        public EfGetAuthorsQuery(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 75;

        public string Name => "Get Authors";

        public IEnumerable<AuthorResultDto> Execute(AuthorSearch search)
        {
            var query = this.context.Authors.AsQueryable();

            BasicFilter(ref query, search);

            throw new NotImplementedException();
        }
    }
}
