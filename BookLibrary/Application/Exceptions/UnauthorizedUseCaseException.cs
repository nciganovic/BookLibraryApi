using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        private IUseCase useCase;
        private IApplicationActor actor;

        public UnauthorizedUseCaseException(IUseCase useCase, IApplicationActor actor)
        {
            this.useCase = useCase;
            this.actor = actor;
        }

        public override string Message => $"Actor with an id of {actor.Id} - {actor.Identity} tried to execute {useCase.Name}.";
    }
}
