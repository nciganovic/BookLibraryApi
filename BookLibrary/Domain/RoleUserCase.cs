namespace Domain
{
    public class RoleUserCase : BaseEntity
    {
        public int RoleId { get; set; }
        public int UseCaseId { get; set; }

        public virtual Role Role { get; set; }
    }
}
