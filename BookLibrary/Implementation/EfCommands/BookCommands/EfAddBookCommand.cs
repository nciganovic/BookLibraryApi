using Application.Commands.Books;
using Application.Dto.Book;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.BookCommands
{
    public class EfAddBookCommand : BaseCommand, IAddBookCommand
    {
        public EfAddBookCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 81;

        public string Name => "Add book";

        public void Execute(Book request)
        {
            context.Books.Add(request);
            context.SaveChanges();
        }
    }
}
