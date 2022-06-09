using Application.Extensions;
using Application.Queries.UseCaseLogs;
using Application.Searches;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.UseCaseLogQueries
{
    public class EfGetUseCaseLogsQuery : BaseQuery<UseCaseLog>, IGetUseCaseLogsQuery
    {
        public EfGetUseCaseLogsQuery(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 121;

        public string Name => "Get use case log query";

        public IEnumerable<UseCaseLog> Execute(UseCaseLogSearch search)
        {
            var query = context.UseCaseLogs.AsQueryable();

            if (search.TimeFrom is not null)
                query = query.Where(x => x.CreatedAt >= search.TimeFrom.ToDate());

            if (search.TimeTo is not null)
                query = query.Where(x => x.CreatedAt <= search.TimeTo.ToDate());

            if (search.Actor is not null)
                query = query.Where(x => x.Actor.ToLower().Contains(search.Actor.ToLower()));

            if (search.UseCaseName is not null)
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));

            BasicFilter(ref query, search);

            return query.OrderByDescending(x => x.CreatedAt);
        }
    }
}
