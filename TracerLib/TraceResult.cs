using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace TracerLib
{
    public class TraceResult
    {
        internal ConcurrentDictionary<int, ThreadTrace> resultDictionary { get; set; }
        internal TraceResult()
        {
            resultDictionary = new ConcurrentDictionary<int, ThreadTrace>();
        }
    }
}
