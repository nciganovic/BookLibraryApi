using Application.Dto.Format;
using Application.Interfaces;

namespace Application.Queries.Format
{
    public interface IGetOneFormatQuery : IQuery<int, FormatResultDto>
    {
    }
}
