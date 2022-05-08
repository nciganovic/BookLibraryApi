using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core
{
    public class FakeApiActor : IApplicationActor
    {
        public int Id => 2;

        public string Identity => "Fake Api Actor";

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(0, 100);
    }
}
