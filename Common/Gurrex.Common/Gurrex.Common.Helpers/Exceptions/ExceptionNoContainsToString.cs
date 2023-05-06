using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Common.Helpers.Exceptions
{
    public class ExceptionNoContainsToString : Exception
    {
        public ExceptionNoContainsToString(string message) : base(message) 
        {
            
        }
    }
}
