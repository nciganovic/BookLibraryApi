using Application.Dto.Membership;
using Application.Dto.Role;

namespace Application.Dto.User
{
    public class UserResultDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public RoleResultDto Role { get; set; }
        public MembershipResultDto Membership { get; set; }
    }
}
