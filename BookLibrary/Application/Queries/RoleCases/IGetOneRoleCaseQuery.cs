using Application.Dto.RoleCase;
using Application.Interfaces;
using Domain;

namespace Application.Queries.RoleCases
{
    public interface IGetOneRoleCaseQuery : IQuery<RoleCaseDto, RoleUserCase>
    {
    }
}
