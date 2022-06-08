using Application.Commands.Reservations;
using AutoMapper;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Implementation.EfCommands.ReservationCommands
{
    public class EfChangeReservationCommand : BaseCommand, IChangeReservationCommand
    {
        public EfChangeReservationCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 102;

        public string Name => "Change reservation";

        public void Execute(Reservation request)
        {
            Reservation reservation = context.Reservations
                .Include(x => x.Books)
                .FirstOrDefault(x => x.Id == request.Id);

            foreach (Book book in reservation.Books)
                context.Books.Find(book.Id).AvailableUnits += 1;

            foreach (Book book in request.Books)
                context.Books.Find(book.Id).AvailableUnits -= 1;

            request.User = context.Users.Find(request.UserId);

            reservation.Books.Clear();
            foreach(var book in request.Books)
                reservation.Books.Add(book);

            reservation.StartTime = request.StartTime;
            reservation.EndTime = request.EndTime;
            reservation.UserId = request.UserId;
            reservation.UpdatedAt = DateTime.Now;

            var entity = context.Reservations.Attach(reservation);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
