using Application.Dto.Publisher;
using Application.Queries.Publishers;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Implementation.Queries.PublisherQueries
{
    public class EfGetPublishersQuery : BaseQuery<Publisher>, IGetPublishersQuery
    {
        private IMapper _mapper;

        public EfGetPublishersQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 45;

        public string Name => "Get publishers";

        public IEnumerable<PublisherResultDto> Execute(PublisherSearch search)
        {
            var query = this.context.Publishers.AsQueryable();

            BasicFilter(ref query, search);

            if (search.Name != null)
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

            return query.OrderBy(x => x.Name).Select(x => _mapper.Map<Publisher, PublisherResultDto>(x)).ToList();
        }
    }
}
