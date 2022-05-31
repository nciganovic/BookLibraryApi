using Application.Commands.Books;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.BookCommands
{
    public class EfChangeBookCommand : BaseCommand, IChangeBookCommand
    {
        public EfChangeBookCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 82;

        public string Name => "Change book";

        public void Execute(Book request)
        {
            Book item = context.Books.Find(request.Id);

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.UpdatedAt = DateTime.Now;

            var entity = context.Books.Attach(request);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
