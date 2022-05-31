using Application.Dto.Book;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validator
{
    public class AddBookValidator : BookValidator<AddBookDto>
    {
        public AddBookValidator(BookLibraryContext context) : base(context)
        {

        }
    }
}