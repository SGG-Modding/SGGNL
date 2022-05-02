using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modding.Exceptions
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
