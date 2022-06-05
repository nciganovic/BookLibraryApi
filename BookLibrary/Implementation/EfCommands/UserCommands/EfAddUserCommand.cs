using Application.Commands.Users;
using Application.Dto.Email;
using Application.Email;
using Application.Hash;
using Application.Interfaces;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.UserCommands
{
    public class EfAddUserCommand : BaseCommand, IAddUserCommand
    {
        private IEmailSender _emailSender;

        public EfAddUserCommand(BookLibraryContext context, IEmailSender emailSender) : base(context)
        {
            _emailSender = emailSender;
        }

        public int Id => 91;

        public string Name => "Add user";

        public void Execute(User request)
        {
            HashSalt hashSalt = Password.GenerateSaltedHash(64, request.Password);

            request.Password = hashSalt.Hash;
            request.Salt = hashSalt.Salt;

            context.Users.Add(request);
            context.SaveChanges();

            //Send email
            SendEmailDto sendEmailDto = new SendEmailDto
            {
                SendTo = request.Email,
                Subject = "Successfull registration to Bug Library",
                Content = "Welcome to Book Library"
            };

            _emailSender.SendEmail(sendEmailDto);
        }
    }
}
