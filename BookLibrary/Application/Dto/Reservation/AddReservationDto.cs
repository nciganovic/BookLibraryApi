using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Reservation
{
    public class AddReservationDto : IReservationCommandDto
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int UserId { get; set; }
        public List<int> BookIds { get; set; }
    }
}
