using System;

namespace Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        private int id;
        private string tableName;

        public EntityNotFoundException(int id, string tableName)
        {
            this.id = id;
            this.tableName = tableName;
        }

        public override string Message => "Entity with id = " + id + " does not exist in table " + tableName;
    }
}
