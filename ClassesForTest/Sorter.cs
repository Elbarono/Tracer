using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerLib.Interface;

namespace Test
{
    public class Sorter
    {
        private ITracer tracer;
        private Finder finder;
        public Sorter(ITracer tracer)
        {
            this.tracer = tracer;
            finder = new Finder(tracer);
        }

        public int[] SortAndFind(int[] mas)
        {
            tracer.StartTrace();

            finder.FindAll(mas);
            mas = Sort(mas);

            tracer.StopTrace();
            return mas;
        }

        public int[] Sort(int[] mas)
        {
            tracer.StartTrace();

            for (int i = 0; i < mas.Length - 1; i++)
            {
                int temp = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] < mas[temp])
                    {
                        temp = j;
                    }
                }
                Swap(mas, temp, i);
            }

            tracer.StopTrace();
            return mas;
        }

        void Swap(int[] mas, int a, int b)
        {
            tracer.StartTrace();

            int temp = mas[a];
            mas[a] = mas[b];
            mas[b] = temp;

            tracer.StopTrace();
        }

    }
}
