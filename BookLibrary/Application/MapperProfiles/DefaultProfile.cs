using Application.Dto.Author;
using Application.Dto.Category;
using Application.Dto.Format;
using Application.Dto.Language;
using Application.Dto.Membership;
using Application.Dto.Publisher;
using Application.Dto.Role;
using AutoMapper;
using Domain;

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
            CreateMap<ChangeRoleDto, Membership>();
            CreateMap<Role, RoleResultDto>();

            CreateMap<AddLanguageDto, Language>();
            CreateMap<ChangeLanguageDto, Membership>();
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
        }
    }
}
