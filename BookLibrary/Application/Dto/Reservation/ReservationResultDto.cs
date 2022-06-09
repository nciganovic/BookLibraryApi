using Application.Dto.Book;
using Application.Dto.User;
using System;
using System.Collections.Generic;

namespace Application.Dto.Reservation
{
    public class ReservationResultDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public UserResultDto User { get; set; }
        public IEnumerable<BookResultDto> Books { get; set; }
    }
}
