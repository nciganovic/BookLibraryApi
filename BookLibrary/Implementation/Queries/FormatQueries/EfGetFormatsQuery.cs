using Application.Dto.Format;
using Application.Queries.Format;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Implementation.Queries.FormatQueries
{
    public class EfGetFormatsQuery : BaseQuery<Format>, IGetFormatsQuery
    {
        private IMapper _mapper;

        public EfGetFormatsQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 55;

        public string Name => "Get formats";

        public IEnumerable<FormatResultDto> Execute(FormatSearch search)
        {
            var query = this.context.Formats.AsQueryable();

            BasicFilter(ref query, search);

            if (search.Name != null)
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

            return query.OrderBy(x => x.Name).Select(x => _mapper.Map<Format, FormatResultDto>(x)).ToList();
        }
    }
}
