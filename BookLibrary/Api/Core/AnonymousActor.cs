using Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Api.Core
{
    public class AnonymousActor : IApplicationActor
    {
        public int Id => 3;

        public string Identity => "Anonymous actor";

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(0, 100);
    }
}
