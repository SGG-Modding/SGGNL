using System;

namespace SGGNL.Exceptions
{
    internal class DuplicateModException : Exception
    {

        public DuplicateModException()
        {
        }

        public DuplicateModException(string message)
            : base(message)
        {
        }

        public DuplicateModException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
