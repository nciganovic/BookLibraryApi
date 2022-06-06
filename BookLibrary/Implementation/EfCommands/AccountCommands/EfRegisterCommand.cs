using Application.Commands.Account;
using Application.Dto.Email;
using Application.Email;
using Application.Exceptions;
using Application.Hash;
using DataAccess;
using Domain;
using System;
using System.Linq;

namespace Implementation.EfCommands.AccountCommands
{
    public class EfRegisterCommand : BaseCommand, IRegisterCommand
    {
        private readonly IEmailSender _emailSender;

        public EfRegisterCommand(BookLibraryContext context, IEmailSender emailSender) : base(context)
        {
            _emailSender = emailSender;
        }

        public int Id => 101;

        public string Name => "Register user";

        public void Execute(User request)
        {
            HashSalt hashSalt = Password.GenerateSaltedHash(64, request.Password);

            request.Password = hashSalt.Hash;
            request.Salt = hashSalt.Salt;

            var basicUserRole = context.Roles.FirstOrDefault(x => x.Name == "Basic User");

            if (basicUserRole is null)
                throw new Exception("Role with name \"Basic User\" does not exist.");

            request.RoleId = basicUserRole.Id;

            context.Users.Add(request);
            context.SaveChanges();

            //Send email
            SendEmailDto sendEmailDto = new SendEmailDto
            {
                SendTo = request.Email,
                Subject = "Successfull registration to Bug Tracker",
                Content = "Welcome to Bug Tracker"
            };

            _emailSender.SendEmail(sendEmailDto);
        }
    }
}
