using Application.Dto.Language;
using Application.Queries.Language;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Implementation.Queries.LanguageQueries
{
    public class EfGetLanguagesQuery : BaseQuery<Language>, IGetLanguagesQuery
    {
        private IMapper _mapper;

        public EfGetLanguagesQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 35;

        public string Name => "Get languages";

        public IEnumerable<LanguageResultDto> Execute(LanguageSearch search)
        {
            var query = this.context.Languages.AsQueryable();

            if (search.Name != null)
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

            BasicFilter(ref query, search);

            return query.OrderBy(x => x.Name).Select(x => _mapper.Map<Language, LanguageResultDto>(x)).ToList();
        }
    }
}
