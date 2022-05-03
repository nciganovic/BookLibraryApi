using System.Collections.Generic;

namespace Domain
{
    public class Membership : BaseEntity
    {
        public string Name { get; set; }
        public decimal MonthlyFee { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
