using Application.Commands.Formats;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.FormatCommands
{
    public class EfChangeFormatCommand : BaseCommand, IChangeFormatCommand
    {
        public EfChangeFormatCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 52;

        public string Name => "Change format";

        public void Execute(Format request)
        {
            Format item = context.Formats.Find(request.Id);

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.UpdatedAt = DateTime.Now;

            var entity = context.Formats.Attach(request);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
