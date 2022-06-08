using Application.Dto.Account;
using Application.Dto.Author;
using Application.Dto.Book;
using Application.Dto.Category;
using Application.Dto.Format;
using Application.Dto.Language;
using Application.Dto.Membership;
using Application.Dto.Publisher;
using Application.Dto.Reservation;
using Application.Dto.Role;
using Application.Dto.User;
using Application.Extensions;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.MapperProfiles
{
    public class DefaultProfile : Profile
    {
        private BookLibraryContext _context;

        public DefaultProfile(BookLibraryContext context)
        {
            _context = context;

            CreateMap<AddMembershipDto, Membership>();
            CreateMap<ChangeMembershipDto, Membership>();
            CreateMap<Membership, MembershipResultDto>();

            CreateMap<AddRoleDto, Role>();
            CreateMap<ChangeRoleDto, Role>();
            CreateMap<Role, RoleResultDto>();

            CreateMap<AddLanguageDto, Language>();
            CreateMap<ChangeLanguageDto, Language>();
            CreateMap<Language, LanguageResultDto>();

            CreateMap<AddPublisherDto, Publisher>();
            CreateMap<ChangePublisherDto, Publisher>();
            CreateMap<Publisher, PublisherResultDto>();

            CreateMap<AddFormatDto, Format>();
            CreateMap<ChangeFormatDto, Format>();
            CreateMap<Format, FormatResultDto>();

            CreateMap<AddCategoryDto, Category>();
            CreateMap<ChangeCategoryDto, Category>();
            CreateMap<Category, CategoryResultDto>();

            CreateMap<AddAuthorDto, Author>();
            CreateMap<ChangeAuthorDto, Author>();
            CreateMap<Author, AuthorResultDto>();

            CreateMap<AddBookDto, Book>().ForMember(b => b.Authors, op => op.MapFrom(new AuhtorIdsResolver(_context)));
            CreateMap<ChangeBookDto, Book>();
            CreateMap<Book, BookResultDto>().ForMember(b => b.Authors, op => op.MapFrom(new AuthorResolver()));

            CreateMap<AddUserDto, User>();
            CreateMap<ChangeUserDto, User>();
            CreateMap<RegisterDto, User>();
            CreateMap<User, UserResultDto>();
            CreateMap<ChangeProfileDto, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<AddReservationDto, Reservation>()
                .ForMember(b => b.Books, op => op.MapFrom(new BookIdsResolver(_context)))
                .ForMember(b => b.StartTime, op => op.MapFrom(new StartDateResolver()))
                .ForMember(b => b.EndTime, op => op.MapFrom(new EndTimeResolver()));
            CreateMap<ChangeReservationDto, Reservation>()
                .ForMember(b => b.Books, op => op.MapFrom(new BookIdsResolver(_context)))
                .ForMember(b => b.StartTime, op => op.MapFrom(new StartDateResolver()))
                .ForMember(b => b.EndTime, op => op.MapFrom(new EndTimeResolver()));
        }
    }

    public class AuthorResolver : IValueResolver<Book, BookResultDto, List<string>>
    {
        public List<string> Resolve(Book source, BookResultDto destination, List<string> member, ResolutionContext context)
        {
            return source.Authors.Select(x => x.FirstName + " " + x.LastName).ToList();
        }
    }

    public class AuhtorIdsResolver : IValueResolver<AddBookDto, Book, ICollection<Author>>
    {
        private BookLibraryContext _context;

        public AuhtorIdsResolver(BookLibraryContext context)
        {
            _context = context;
        }

        public ICollection<Author> Resolve(AddBookDto source, Book destination, ICollection<Author> destMember, ResolutionContext context)
        {
            return source.AuthorIds.Select(x => _context.Authors.Find(x)).ToList();
        }
    }

    public class BookIdsResolver : IValueResolver<IReservationCommandDto, Reservation, ICollection<Book>>
    {
        private BookLibraryContext _context;

        public BookIdsResolver(BookLibraryContext context)
        {
            _context = context;
        }

        public ICollection<Book> Resolve(IReservationCommandDto source, Reservation destination, ICollection<Book> destMember, ResolutionContext context)
        {
            return source.BookIds.Select(x => _context.Books.Find(x)).ToList();
        }
    }

    public class StartDateResolver : IValueResolver<IReservationCommandDto, Reservation, DateTime>
    {
        public DateTime Resolve(IReservationCommandDto source, Reservation destination, DateTime destMember, ResolutionContext context)
        {
            return source.StartTime.ToDate();
        }
    }

    public class EndTimeResolver : IValueResolver<IReservationCommandDto, Reservation, DateTime>
    {
        public DateTime Resolve(IReservationCommandDto source, Reservation destination, DateTime destMember, ResolutionContext context)
        {
            return source.EndTime.ToDate();
        }
    }
}
