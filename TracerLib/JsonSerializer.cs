using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using TracerLib.Interface;
using TracerLib.ResultClasses;

namespace TracerLib
{
    public class JsonSerializer : ISerialize,IWriter
    {
        private ITracer tracer;
        public JsonSerializer(ITracer tracer)
        {
            this.tracer = tracer;
        }
        public void Serialize(List<ResultClasses.Thread> traceResult)
        {

            ResultClasses.Thread[] traceResultDtos = traceResult.ToArray();

            using (FileStream fs = new FileStream("traceResult.json", FileMode.Create))
            {
                System.Text.Json.JsonSerializer.SerializeAsync<List<ResultClasses.Thread>>(fs, traceResult, new JsonSerializerOptions()
                {
                    WriteIndented = true
                });

                Console.WriteLine("Object has been serialized");
            }
        }

        public void WriteResults()
        {
            ListResult listResult = new ListResult();
            var ListThr = listResult.GetTraceResultL(tracer.GetTraceResult());
            Serialize(ListThr);
        }
    }
}
