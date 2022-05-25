using Application.Searches;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands
{
    public abstract class BaseCommand
    {
        protected BookLibraryContext context { get; }

        protected BaseCommand(BookLibraryContext context)
        {
            this.context = context;
        }
    }
}
