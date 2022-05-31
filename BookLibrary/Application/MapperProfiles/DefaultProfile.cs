using Application.Dto.Author;
using Application.Dto.Book;
using Application.Dto.Category;
using Application.Dto.Format;
using Application.Dto.Language;
using Application.Dto.Membership;
using Application.Dto.Publisher;
using Application.Dto.Role;
using AutoMapper;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application.MapperProfiles
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
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

            CreateMap<AddBookDto, Book>();
            CreateMap<ChangeBookDto, Book>();
            CreateMap<Book, BookResultDto>().ForMember(b => b.Authors, op => op.MapFrom(new AuthorResolver()));
        }
    }

    public class AuthorResolver : IValueResolver<Book, BookResultDto, List<string>>
    {
        public List<string> Resolve(Book source, BookResultDto destination, List<string> member, ResolutionContext context)
        {
            return source.Authors.Select(x => x.FirstName + " " + x.LastName).ToList();
        }
    }
}
