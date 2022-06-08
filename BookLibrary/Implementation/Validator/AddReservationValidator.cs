using Application.Dto.Reservation;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validator
{
    public class AddReservationValidator : ReservationValidator<AddReservationDto>
    {
        public AddReservationValidator(BookLibraryContext context) : base(context)
        {

        }
    }
}
