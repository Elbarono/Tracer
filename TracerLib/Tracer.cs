using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerLib.Interface;

namespace TracerLib
{
    public class Tracer:ITracer
    {
        private TraceResult traceResult;
        public Tracer()
        {
            traceResult = new TraceResult();
        }
        public TraceResult GetTraceResult()
        {
            return traceResult;
        }

        public void StartTrace()
        {
            lock (this)
            {
                MethodTraceList invokedMethod = new MethodTraceList();
                int threadId = Thread.CurrentThread.ManagedThreadId;
                ThreadTrace threadtrace = traceResult.resultDictionary.GetOrAdd(threadId, (threadId) => new ThreadTrace());
                threadtrace.methodsStack.Push(invokedMethod);
            }
        }

        public void StopTrace()
        {
            lock (this)
            {
                long endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                int threadId = Thread.CurrentThread.ManagedThreadId;
                ThreadTrace threadtrace = traceResult.resultDictionary.GetOrAdd(threadId, (threadId) => new ThreadTrace());
                MethodTraceList ThisMethod = threadtrace.methodsStack.Pop();
                if (threadtrace.methodsStack.Count != 0)
                {
                    MethodTraceList invoker = threadtrace.methodsStack.Peek();
                    ThisMethod.ParentMethod = invoker;
                    invoker.ChildMethods.Add(ThisMethod);
                }
                else
                {
                    threadtrace.invokedMethods = ThisMethod;
                }

                StackTrace stackTrace = new StackTrace();
                var method = stackTrace.GetFrame(1).GetMethod();
                string methodName = method.Name;
                string className = method.DeclaringType.Name;
                long elapsedTime = endTime - ThisMethod.AddingToStackTime;

                ThisMethod.ThisMethod = new MethodTrace(methodName, className, elapsedTime);
            }
        }
    }
}
