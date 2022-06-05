using Application.Commands.Users;
using Application.Hash;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.UserCommands
{
    public class EfChangeUserCommand : BaseCommand, IChangeUserCommand
    {
        public EfChangeUserCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 92;

        public string Name => "Change user";

        public void Execute(User request)
        {
            User user = context.Users.Find(request.Id);
            HashSalt hashSalt = Password.GenerateSaltedHash(64, request.Password);

            context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.UpdatedAt = DateTime.Now;
            request.Password = hashSalt.Hash;
            request.Salt = hashSalt.Salt;

            var entity = context.Users.Attach(request);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
