using Application.Interfaces;
using Domain;

namespace Application.Commands.Languages
{
    public interface IChangeLanguageCommand : ICommand<Language>
    {
    }
}
