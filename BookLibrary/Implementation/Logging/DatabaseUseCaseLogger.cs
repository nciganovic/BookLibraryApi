using Application.Interfaces;
using DataAccess;
using System;
using Domain;
using Newtonsoft.Json;

namespace Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private BookLibraryContext _context; 

        public DatabaseUseCaseLogger(BookLibraryContext context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IApplicationActor applicationActor, object useCaseData)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                Actor = applicationActor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.Now,
                UseCaseName = useCase.Name
            });

            _context.SaveChanges();
        }
    }
}
