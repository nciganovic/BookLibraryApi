using Application.Commands.Formats;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.FormatCommands
{
    public class EfRemoveFormatCommand : BaseCommand, IRemoveFormatCommand
    {
        public EfRemoveFormatCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 53;

        public string Name => "Remove format";

        public void Execute(int request)
        {
            Format item = context.Formats.Find(request);

            if (item == null)
                throw new EntityNotFoundException(request, "Format");

            item.DeletedAt = DateTime.Now;

            context.Formats.Update(item);
            context.SaveChanges();
        }
    }
}
