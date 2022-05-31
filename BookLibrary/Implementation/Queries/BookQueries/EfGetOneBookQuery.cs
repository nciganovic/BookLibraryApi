using Application.Dto.Book;
using Application.Dto.Category;
using Application.Dto.Format;
using Application.Dto.Language;
using Application.Dto.Publisher;
using Application.Queries.Books;
using AutoMapper;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.BookQueries
{
    public class EfGetOneBookQuery : BaseQuery<Book>, IGetOneBookQuery
    {
        private IMapper _mapper;

        public EfGetOneBookQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 84;

        public string Name => "Get one book";

        public BookResultDto Execute(int search)
        {
            Book book = context.Books.Include(i => i.Category)
              .Include(i => i.Format)
              .Include(i => i.Publisher)
              .Include(i => i.Language)
              .Include(i => i.Authors)
              .FirstOrDefault(x => x.Id == search);

            if (book == null)
                return null;

            return _mapper.Map<Book, BookResultDto>(book);
        }
    }
}
