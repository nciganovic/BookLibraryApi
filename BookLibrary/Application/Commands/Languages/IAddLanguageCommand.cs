using Application.Interfaces;
using Domain;

namespace Application.Commands.Languages
{
    public interface IAddLanguageCommand : ICommand<Language>
    {
    }
}
