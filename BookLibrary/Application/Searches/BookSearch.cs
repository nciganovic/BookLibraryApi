using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class BookSearch : BaseSearch
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? MaxPages { get; set; }
        public int? MinPages { get; set; }
        public int? MaxYear { get; set; }
        public int? MinYear { get; set; }
        public int? MinAvailableUnits { get; set; }
        public int? MaxAvailableUnits { get; set; }
        public int? PublisherId { get; set; }
        public int? LanguageId { get; set; }
        public int? CategoryId { get; set; }
        public int? FormatId { get; set; }
        public int? AuthorId { get; set; }
    }
}
