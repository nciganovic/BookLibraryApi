using Application.Commands.Reservations;
using DataAccess;
using Domain;

namespace Implementation.EfCommands.ReservationCommands
{
    public class EfAddReservationCommand : BaseCommand, IAddReservationCommand
    {
        public EfAddReservationCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 111;

        public string Name => "Add reservation";

        public void Execute(Reservation request)
        {
            context.Reservations.Add(request);

            foreach (Book book in request.Books)
            {
                context.Books.Find(book.Id).AvailableUnits -= 1;
            }

            context.SaveChanges();
        }
    }
}
