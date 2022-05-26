namespace Application.Searches
{
    public abstract class BaseSearch
    {
        public bool? OnlyActive { get; set; }
        public int? Page { get; set; }
        public int? ItemsPerPage { get; set; }
    }
}
