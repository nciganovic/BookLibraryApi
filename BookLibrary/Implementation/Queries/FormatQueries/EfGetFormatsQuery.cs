using Application.Dto.Format;
using Application.Queries.Format;
using Application.Searches;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;

namespace Implementation.Queries.FormatQueries
{
    public class EfGetFormatsQuery : BaseQuery<Format>, IGetFormatsQuery
    {
        public EfGetFormatsQuery(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 55;

        public string Name => "Get formats";

        public IEnumerable<FormatResultDto> Execute(FormatSearch search)
        {
            var query = this.context.Formats.AsQueryable();

            BasicFilter(ref query, search);

            throw new NotImplementedException();
        }
    }
}
