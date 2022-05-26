namespace Application.Searches
{
    public class MembershipSearch : BaseSearch
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? MonthlyFeeFrom { get; set; }
        public decimal? MonthlyFeeTo { get; set; }
    }
}
