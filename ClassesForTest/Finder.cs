using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerLib.Interface;

namespace Test
{
    public class Finder
    {
        ITracer tracer;
        public Finder(ITracer tracer)
        {
            this.tracer = tracer;
        }
        public int[] FindAll(int[] mas)
        {
            tracer.StartTrace();

            FindMax(mas);
            FindMin(mas);

            tracer.StopTrace();
            return mas;
        }

        void FindMax(int[] mas)
        {
            tracer.StartTrace();

            int max = mas[0];
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > max)
                {
                    max = mas[i];
                }
            }
            Console.WriteLine(max);

            tracer.StopTrace();
        }

        void FindMin(int[] mas)
        {
            tracer.StartTrace();

            int min = mas[0];
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] < min)
                {
                    min = mas[i];
                }
            }
            Console.WriteLine(min);

            tracer.StopTrace();
        }
    }
}
