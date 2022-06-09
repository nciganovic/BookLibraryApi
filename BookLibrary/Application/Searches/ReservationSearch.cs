using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class ReservationSearch : BaseSearch
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }
    }
}
