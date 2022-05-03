using System;
using System.Collections.Generic;

namespace Domain
{
    public class Reservation : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
