using System.Collections.Generic;

namespace Domain
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
