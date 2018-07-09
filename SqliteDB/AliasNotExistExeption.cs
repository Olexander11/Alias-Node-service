using System;

namespace SqliteDB
{
    public class AliasNotExistExeption : Exception
    {
        public AliasNotExistExeption()
        {
        }

        public AliasNotExistExeption(String message)
            : base(message)
        {
        }
    }
}