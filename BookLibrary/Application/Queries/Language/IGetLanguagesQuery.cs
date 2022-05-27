using Application.Dto.Language;
using Application.Interfaces;
using Application.Searches;
using System.Collections.Generic;

namespace Application.Queries.Language
{
    public interface IGetLanguagesQuery : IQuery<LanguageSearch, IEnumerable<LanguageResultDto>>
    {
    }
}
