using Application.Dto.Category;
using Application.Dto.Format;
using Application.Dto.Language;
using Application.Dto.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Book
{
    public class BookResultDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public int AvailableUnits { get; set; }
        public string CoverImageSource { get; set; }
        public string ContentFileSource { get; set; }
        public int Year { get; set; }
        public PublisherResultDto Publisher { get; set; }
        public LanguageResultDto Language { get; set; }
        public CategoryResultDto Category { get; set; }
        public FormatResultDto Format { get; set; }
        public List<string> Authors { get; set; }
    }
}
