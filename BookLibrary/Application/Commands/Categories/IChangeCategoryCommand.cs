using Application.Interfaces;
using Domain;

namespace Application.Commands.Categories
{
    public interface IChangeCategoryCommand : ICommand<Category>
    {
    }
}
