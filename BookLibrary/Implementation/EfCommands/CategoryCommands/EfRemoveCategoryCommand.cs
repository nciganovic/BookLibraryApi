using Application.Commands.Categories;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.FormatCommands
{
    public class ERemoveCategoryCommand : BaseCommand, IRemoveCategoryCommand
    {
        public ERemoveCategoryCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 63;

        public string Name => "Remove category";

        public void Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}
