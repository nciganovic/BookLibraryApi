using System.Collections.Generic;

namespace Domain
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
        public ICollection<RoleUserCase> RoleUserCases { get; set; } = new HashSet<RoleUserCase>();
    }
}
