﻿using Application.Commands.Categories;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.FormatCommands
{
    public class EfChangeCategoryCommand : BaseCommand, IChangeCategoryCommand
    {
        public EfChangeCategoryCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 62;

        public string Name => "Change category";

        public void Execute(Category request)
        {
            throw new NotImplementedException();
        }
    }
}
