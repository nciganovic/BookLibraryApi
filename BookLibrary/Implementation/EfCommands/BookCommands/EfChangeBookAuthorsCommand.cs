using Application.Commands.Books;
using Application.Dto.Book;
using Application.Exceptions;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Implementation.EfCommands.BookCommands
{
    public class EfChangeBookAuthorsCommand : BaseCommand, IChangeBookAuthorsCommand
    {
        private BookLibraryContext _context;

        public EfChangeBookAuthorsCommand(BookLibraryContext context) : base(context)
        {
            _context = context;
        }

        public int Id => 86;

        public string Name => "Change Book authros";

        public void Execute(ChangeBookAuthorsDto request)
        {
            Book book = _context.Books.Include(x => x.Authors).Where(x => x.Id == request.BookId).FirstOrDefault();

            if (book is null)
                throw new EntityNotFoundException(request.BookId, "Books");

            if (request.AuthorIds is null)
                return;

            book.Authors.Clear();
            
            foreach (int authorId in request.AuthorIds)
            {
                Author author = _context.Authors.Find(authorId);
                book.Authors.Add(author);
            }

            book.UpdatedAt = DateTime.Now;

            var entity = context.Books.Attach(book);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
