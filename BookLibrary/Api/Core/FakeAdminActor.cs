using Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Api.Core
{
    public class FakeAdminActor : IApplicationActor
    {
        public int Id => 2;

        public string Identity => "Fake Admin Actor";

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(0, 1000);
    }
}
