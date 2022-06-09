using Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Api.Core
{
    public class AnonymousActor : IApplicationActor
    {
        public int Id => 3;

        public string Identity => "Anonymous actor";

        public IEnumerable<int> AllowedUseCases => new int[] { 101 }; //Only register and login allowed
    }
}
