using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib
{
    public class ThreadTrace
    {
        public Stack<MethodTraceList> methodsStack { get; set; }
        public MethodTraceList invokedMethods { get; set; }
        public ThreadTrace()
        {
            methodsStack = new Stack<MethodTraceList>();
        }
    }
}
