using Application.Commands.Categories;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.FormatCommands
{
    public class EfChangeCategoryCommand : BaseCommand, IChangeCategoryCommand
    {
        public EfChangeCategoryCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 62;

        public string Name => "Change category";

        public void Execute(Category request)
        {
            Category item = context.Categories.Find(request.Id);

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.UpdatedAt = DateTime.Now;

            var entity = context.Categories.Attach(request);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
