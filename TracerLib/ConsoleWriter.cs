using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerLib.Interface;
using TracerLib.ResultClasses;

namespace TracerLib
{
    public class ConsoleWriter : IWriter
    {
        private ITracer tracer;
        public ConsoleWriter(ITracer tracer)
        {
            this.tracer = tracer;
        }
        public void WriteResults()
        {
            ListResult listResult = new ListResult();
            var ListThr = listResult.GetTraceResultL(tracer.GetTraceResult());

            ListThr.ForEach(result => 
            {
                string res = "Thread\n" +
                "id : " + result.id + "\n" +
                "time : " + result.time + "\n\n";              

                res += GetMethodString(result.methods, 1);

                Console.WriteLine(res);
            });
        }

        string GetMethodString(Method methods, int tabCount)
        {
            string methInfo = Tabs(tabCount) + "Method\n" +
                Tabs(tabCount) + "Name : " + methods.Name + "\n" +
                Tabs(tabCount) + "Class : " + methods.Class + "\n" +
                Tabs(tabCount) + "Time : " + methods.Time + "\n\n";
            foreach (var method in methods.methods)
            {
                methInfo += GetMethodString(method, tabCount + 1);
            }
            return methInfo;
        }

        string Tabs(int tabCount)
        {
            string tabs = "";
            for (int i = 0; i < tabCount; i++)
            {
                tabs += "\t";
            }
            return tabs;
        }
    }
}
