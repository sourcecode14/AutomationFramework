using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.ExceptionExtensions
{
    class DuplicateIdException : Exception
    {
        public DuplicateIdException(string message) : base(message) { }
    }
}
