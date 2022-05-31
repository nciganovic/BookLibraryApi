using Microsoft.AspNetCore.Http;

namespace Application.Dto.Book
{
    public interface IBookCommandDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public int AvailableUnits { get; set; }
        public string CoverImageSource { get; set; }
        public string ContentFileSource { get; set; }
        public int Year { get; set; }
        public int PublisherId { get; set; }
        public int LanguageId { get; set; }
        public int CategoryId { get; set; }
        public int FormatId { get; set; }
        public int[] AuthorIds { get; set; }
        public IFormFile CoverImage { get; set; }
        public IFormFile ContentFile { get; set; }
    }
}
