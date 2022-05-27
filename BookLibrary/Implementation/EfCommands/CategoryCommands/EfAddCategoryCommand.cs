using Application.Commands.Categories;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.FormatCommands
{
    public class EfAddCategoryCommand : BaseCommand, IAddCategoryCommand
    {
        public EfAddCategoryCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 61;

        public string Name => "Add category";

        public void Execute(Category request)
        {
            throw new NotImplementedException();
        }
    }
}
