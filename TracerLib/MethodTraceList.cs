using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib
{
    public class MethodTraceList
    {
        public MethodTraceList()
        {
            ChildMethods = new List<MethodTraceList>();
            AddingToStackTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }
        public long AddingToStackTime { get; }
        public MethodTrace ThisMethod { set; get; }
        public MethodTraceList ParentMethod { set; get; }
        public List<MethodTraceList> ChildMethods { get; }
    }
}
