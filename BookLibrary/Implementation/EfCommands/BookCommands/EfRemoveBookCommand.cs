using Application.Commands.Books;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.BookCommands
{
    public class EfRemoveBookCommand : BaseCommand, IRemoveBookCommand
    {
        public EfRemoveBookCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 83;

        public string Name => "Remove book";

        public void Execute(int request)
        {
            Book item = context.Books.Find(request);

            if (item == null)
                throw new EntityNotFoundException(request, "Book");

            item.DeletedAt = DateTime.Now;

            context.Books.Update(item);
            context.SaveChanges();
        }
    }
}
