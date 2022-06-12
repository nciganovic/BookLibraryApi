using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Book
{
    public class ChangeBookAuthorsDto
    {
        public int BookId { get; set; }
        public int[] AuthorIds { get; set; }
    }
}
