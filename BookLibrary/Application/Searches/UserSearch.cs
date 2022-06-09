namespace Application.Searches
{
    public class UserSearch : BaseSearch
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public int MembershipId { get; set; }
    }
}
