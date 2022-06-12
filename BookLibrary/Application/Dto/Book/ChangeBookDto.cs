using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Book
{
    public class ChangeBookDto : IBookCommandDto
    {
        public int Id { get; set; }
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
        public IFormFile CoverImage { get; set; }
        public IFormFile ContentFile { get; set; }
    }
}
