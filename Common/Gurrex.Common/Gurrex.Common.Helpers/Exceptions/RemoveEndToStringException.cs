using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Common.Helpers.Exceptions
{
    /// <summary>
    /// Исключение при несоответсвии длины строки
    /// </summary>
    public class RemoveEndToStringException : Exception
    {
        public RemoveEndToStringException(string message) : base(message)
        {
            
        }
    }
}
