using Gurrex.Common.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Common.Services.Models.Events
{
    public class ProcessEventArgs : EventArgs
    {
        public ProcessOutputLevel ProcessOutputLevel { get; }
        public string Output { get; }

        public ProcessEventArgs(ProcessOutputLevel processOutputLevel, string output) 
        {
            ProcessOutputLevel = processOutputLevel;
            Output = output;
        }
    }
}
