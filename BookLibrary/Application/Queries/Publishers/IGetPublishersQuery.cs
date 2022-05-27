using Application.Dto.Publisher;
using Application.Interfaces;
using Application.Searches;
using System.Collections.Generic;

namespace Application.Queries.Publishers
{
    public interface IGetPublishersQuery : IQuery<PublisherSearch, IEnumerable<PublisherResultDto>>
    {
    }
}
