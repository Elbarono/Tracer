using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using TracerLib.Interface;
using TracerLib.ResultClasses;

namespace TracerLib
{
    public class XmlSerializer : IWriter, ISerialize
    {
        private ITracer tracer;
        public XmlSerializer(ITracer tracer)
        {
            this.tracer = tracer;
        }
        public void Serialize(List<ResultClasses.Thread> traceResult)
        {
            ResultClasses.Thread[] traceResultDtos = traceResult.ToArray();
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(List<ResultClasses.Thread>));

            using (FileStream fs = new FileStream("traceResult.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, traceResult);

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
