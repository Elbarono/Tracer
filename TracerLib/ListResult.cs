using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerLib.ResultClasses;

namespace TracerLib
{
    public class ListResult
    {
        long time;
        internal List<ResultClasses.Thread> GetTraceResultL(TraceResult traceResult)
        {
            List<ResultClasses.Thread> ListThr = new List<ResultClasses.Thread>();
            var enumerator = traceResult.resultDictionary.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ResultClasses.Thread threadR = new ResultClasses.Thread();
                time = 0;
                int ti = enumerator.Current.Key;
                MethodTraceList methodTraceList = enumerator.Current.Value.invokedMethods;
                Method methodDto = GetMethodResult(methodTraceList);
                threadR.methods = GetMethodResult(methodTraceList);
                threadR.id = ti;
                threadR.time = time;
                ListThr.Add(threadR);
            }
            return ListThr;
        }
        Method GetMethodResult(MethodTraceList methodTraceList)
        {
            List<Method> childMethodList = new List<Method>();
            foreach (var method in methodTraceList.ChildMethods)
            {
                childMethodList.Add(GetMethodResult(method));
            }
            Method methodR = GetMethodResult(methodTraceList.ThisMethod);
            methodR.methods = childMethodList.ToArray();
            return methodR;
        }

        Method GetMethodResult(MethodTrace methodTrace)
        {
            Method methodR = new Method();
            methodR.Name = methodTrace.MethodName;
            methodR.Time = methodTrace.ElapsedTime;
            methodR.Class = methodTrace.ClassName;
            time += methodTrace.ElapsedTime;
            return methodR;
        }
    }
}
