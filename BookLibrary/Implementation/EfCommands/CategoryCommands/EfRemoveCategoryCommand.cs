using Application.Commands.Categories;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.FormatCommands
{
    public class EfRemoveCategoryCommand : BaseCommand, IRemoveCategoryCommand
    {
        public EfRemoveCategoryCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 63;

        public string Name => "Remove category";

        public void Execute(int request)
        {
            Category item = context.Categories.Find(request);

            if (item == null)
                throw new EntityNotFoundException(request, "Category");

            item.DeletedAt = DateTime.Now;

            context.Categories.Update(item);
            context.SaveChanges();
        }
    }
}
