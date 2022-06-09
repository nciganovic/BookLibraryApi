using Application.Interfaces;
using Application.Searches;
using Domain;
using System.Collections.Generic;

namespace Application.Queries.UseCaseLogs
{
    public interface IGetUseCaseLogsQuery : IQuery<UseCaseLogSearch, IEnumerable<UseCaseLog>>
    {
    }
}
