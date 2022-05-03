using System.Collections.Generic;

namespace Domain
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public int AvailableUnits { get; set; }
        public string CoverImageSource { get; set; }
        #nullable enable
        public string? ContentFileSource { get; set; }
        #nullable disable
        public int Year { get; set; }
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public int LanguagueId { get; set; }
        public virtual Languague Languague { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int FormatId { get; set; }
        public virtual Format Format { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
        public ICollection<Author> Authors { get; set; } = new HashSet<Author>();
    }
}
