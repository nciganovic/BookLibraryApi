using Application.Dto.Publisher;
using Application.Interfaces;

namespace Application.Queries.Publishers
{
    public interface IGetOnePublisherQuery : IQuery<int, PublisherResultDto>
    {
    }
}
