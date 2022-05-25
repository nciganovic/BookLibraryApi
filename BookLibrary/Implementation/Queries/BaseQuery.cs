using Application.Extensions;
using Application.Searches;
using DataAccess;
using Domain;
using System.Linq;

namespace Implementation.Queries
{
    public abstract class BaseQuery<T> where T : BaseEntity
    {
        protected BookLibraryContext context { get; }

        protected BaseQuery(BookLibraryContext context)
        {
            this.context = context;
        }

        protected void BasicFilter(ref IQueryable<T> query, BaseSearch search)
        {
            if(search.OnlyActive == true)
                query = query.Where(x => x.DeletedAt == null);
            
            query = query.SkipItems(search.Page, search.ItemsPerPage);
        }
    }
}
