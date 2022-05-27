using Application.Dto.Format;
using Application.Interfaces;
using Application.Searches;
using System.Collections.Generic;

namespace Application.Queries.Format
{
    public interface IGetFormatsQuery : IQuery<FormatSearch, IEnumerable<FormatResultDto>>
    {
    }
}
