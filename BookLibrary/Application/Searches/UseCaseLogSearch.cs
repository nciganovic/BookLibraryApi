namespace Application.Searches
{
    public class UseCaseLogSearch : BaseSearch
    {
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public string Actor { get; set; }
        public string UseCaseName { get; set; }
    }
}
