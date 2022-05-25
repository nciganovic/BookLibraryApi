using Application.Searches;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Filter
{
    public static class BaseSearchFilter<T> where T : BaseEntity
    {
        public static IQueryable<T> Filter(IQueryable<T> query, BaseSearch search) 
        {
            query = query.Where(x => (x.DeletedAt == null) == search.OnlyActive);
            return query;
        }
}
}
