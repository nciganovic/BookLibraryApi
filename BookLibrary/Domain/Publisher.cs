using System.Collections.Generic;

namespace Domain
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
