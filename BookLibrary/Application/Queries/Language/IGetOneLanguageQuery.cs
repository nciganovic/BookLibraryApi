using Application.Dto.Language;
using Application.Interfaces;

namespace Application.Queries.Language
{
    public interface IGetOneLanguageQuery : IQuery<int, LanguageResultDto>
    {
    }
}
