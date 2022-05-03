using System.Collections.Generic;

namespace Domain
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int MembershipId { get; set; }
        public virtual Membership Membership { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
    }
}
