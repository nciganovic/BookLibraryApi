using Application.Commands.Account;
using Application.Hash;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.AccountCommands
{
    public class EfChangeProfileCommand : BaseCommand, IChangeProfileCommand
    {
        public EfChangeProfileCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 102;

        public string Name => "Change profile";

        public void Execute(User request)
        {
            User user = context.Users.Find(request.Id);
            
            context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.UpdatedAt = DateTime.Now;

            request.FirstName ??= user.FirstName;
            request.LastName ??= user.LastName;
            request.Email ??= user.Email;

            if (request.MembershipId == 0)
                request.MembershipId = user.MembershipId;

            request.RoleId = user.RoleId;

            if (request.Password is not null)
            {
                HashSalt hashSalt = Password.GenerateSaltedHash(64, request.Password);
                request.Password = hashSalt.Hash;
                request.Salt = hashSalt.Salt;
            }
            else
            { 
                request.Password = user.Password;
                request.Salt = user.Salt;
            }

            var entity = context.Users.Attach(request);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
