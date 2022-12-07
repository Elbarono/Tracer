using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib.Interface
{
    public interface ITracer
    {
        void StartTrace();

        void StopTrace();

        public TraceResult GetTraceResult();
    }

}
