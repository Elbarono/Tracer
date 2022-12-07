using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib
{
    public class MethodTrace
    {
        public MethodTrace(string methodName, string className, long elapsedTime)
        {
            MethodName = methodName;
            ClassName = className;
            ElapsedTime = elapsedTime;
        }
        public MethodTrace()
        {
        }
        public string MethodName { get; set; }
        public string ClassName { get; set; }
        public long ElapsedTime { get; set; }
    }
}
