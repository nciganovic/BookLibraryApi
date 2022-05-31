using Application.Dto.Book;
using Application.Dto.Category;
using Application.Dto.Format;
using Application.Dto.Language;
using Application.Dto.Publisher;
using Application.Queries.Books;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Implementation.Queries.BookQueries
{
    public class EfGetBooksQuery : BaseQuery<Book>, IGetBooksQuery
    {
        private IMapper _mapper;

        public EfGetBooksQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 85;

        public string Name => "Get books";

        public IEnumerable<BookResultDto> Execute(BookSearch search)
        {
            var query = context.Books
                .Include(x => x.Authors)
                .Include(i => i.Format)
                .Include(i => i.Publisher)
                .Include(i => i.Language)
                .Include(i => i.Authors)
                .AsQueryable();

            BasicFilter(ref query, search);

            if (search.Title != null)
                query = query.Where(x => x.Title.ToLower().Contains(search.Title.ToLower()));

            if (search.Description != null)
                query = query.Where(x => x.Description.ToLower().Contains(search.Description.ToLower()));

            if (search.MinPages != null)
                query = query.Where(x => x.Pages >= search.MinPages);

            if (search.MaxPages != null)
                query = query.Where(x => x.Pages <= search.MaxPages);

            if (search.MinYear != null)
                query = query.Where(x => x.Year >= search.MinYear);

            if (search.MaxAvailableUnits != null)
                query = query.Where(x => x.Year <= search.MaxAvailableUnits);

            if (search.MinAvailableUnits != null)
                query = query.Where(x => x.AvailableUnits >= search.MinAvailableUnits);

            if (search.MaxAvailableUnits != null)
                query = query.Where(x => x.AvailableUnits <= search.MaxAvailableUnits);

            if (search.PublisherId != null)
                query = query.Where(x => x.PublisherId <= search.PublisherId);

            if (search.LanguageId != null)
                query = query.Where(x => x.LanguageId <= search.LanguageId);

            if (search.CategoryId != null)
                query = query.Where(x => x.CategoryId <= search.CategoryId);

            if (search.FormatId != null)
                query = query.Where(x => x.FormatId <= search.FormatId);

            if (search.AuthorId != null)
                query = query.Where(x => x.Authors.Any(x => x.Id == search.AuthorId));

            return query.OrderBy(x => x.Title).Select(x => _mapper.Map<Book, BookResultDto>(x)); 
        }
    }
}
