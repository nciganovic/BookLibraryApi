namespace Application.Dto.User
{
    public interface IUserCommandDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int MembershipId { get; set; }
    }
}
