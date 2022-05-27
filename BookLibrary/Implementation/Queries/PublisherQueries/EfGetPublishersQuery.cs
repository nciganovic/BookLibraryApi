using Application.Dto.Publisher;
using Application.Queries.Publishers;
using Application.Searches;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;

namespace Implementation.Queries.PublisherQueries
{
    public class EfGetPublishersQuery : BaseQuery<Publisher>, IGetPublishersQuery
    {
        public EfGetPublishersQuery(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 45;

        public string Name => "Get publishers";

        public IEnumerable<PublisherResultDto> Execute(PublisherSearch search)
        {
            var query = this.context.Publishers.AsQueryable();

            BasicFilter(ref query, search);

            throw new NotImplementedException();
        }
    }
}
