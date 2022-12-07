using TracerLib;
using Test;
using TracerLib.Interface;

namespace Tracer
{
    class Program
    {
        static void Main(string[] args)
        {
            ITracer tracer = new TracerLib.Tracer();
            Sorter sorter = new Sorter(tracer);
            Finder finder = new Finder(tracer);

            Thread thread = new Thread(new ThreadStart(() => finder.FindAll(new int[] { 1, 23, 5, 10, 13, 6, 10, 12 })));

            thread.Start();
            sorter.SortAndFind(new int[] { -2, 8, 6, 3, 5 });
            thread.Join();

            IWriter Console = new ConsoleWriter(tracer);
            Console.WriteResults();

            IWriter Xml = new XmlSerializer(tracer);
            Xml.WriteResults();

            IWriter Json = new JsonSerializer(tracer);            
            Json.WriteResults();
        }

    }
}