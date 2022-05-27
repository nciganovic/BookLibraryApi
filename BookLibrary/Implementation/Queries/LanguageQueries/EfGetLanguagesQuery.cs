using Application.Dto.Language;
using Application.Queries.Language;
using Application.Searches;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.LanguageQueries
{
    public class EfGetLanguagesQuery : BaseQuery<Language>, IGetLanguagesQuery
    {
        public EfGetLanguagesQuery(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 35;

        public string Name => "Get languages";

        public IEnumerable<LanguageResultDto> Execute(LanguageSearch search)
        {
            var query = this.context.Languages.AsQueryable();

            BasicFilter(ref query, search);

            throw new NotImplementedException();
        }
    }
}
