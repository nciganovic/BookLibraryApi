using Application.Commands.Languages;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.LanguageCommands
{
    public class EfChangeLanguageCommand : BaseCommand, IChangeLanguageCommand
    {
        public EfChangeLanguageCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 32;

        public string Name => "Change language";

        public void Execute(Language request)
        {
            Language item = context.Languages.Find(request.Id);

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.UpdatedAt = DateTime.Now;

            var entity = context.Languages.Attach(request);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
