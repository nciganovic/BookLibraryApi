using Application.Commands.Reservations;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.ReservationCommands
{
    public class EfRemoveReservationCommand : BaseCommand, IRemoveReservationCommand
    {
        public EfRemoveReservationCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 113;

        public string Name => "Remove reservation";

        public void Execute(int request)
        {
            Reservation item = context.Reservations.Find(request);

            if (item == null)
                throw new EntityNotFoundException(request, "Reservation");

            item.DeletedAt = DateTime.Now;

            context.Reservations.Update(item);
            context.SaveChanges();
        }
    }
}
