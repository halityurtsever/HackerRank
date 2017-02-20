using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scope
{
    class Program
    {
        static void Main(string[] args)
        {
            Convert.ToInt32(Console.ReadLine());

            int[] a = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

            Difference d = new Difference(a);

            d.computeDifference();

            Console.Write(d.maximumDifference);
        }
    }

    internal class Difference
    {
        private int[] elements;
        public int maximumDifference;

        public Difference(int[] ints)
        {
            elements = ints;
        }

        public void computeDifference()
        {
            var maxValue = 0;
            var minValue = 0;

            for (int i = 0; i < elements.Length; i++)
            {
                if (maxValue == 0 && minValue == 0)
                {
                    maxValue = elements[i];
                    minValue = elements[i];
                }
                else
                {
                    if (elements[i] < minValue)
                    {
                        minValue = elements[i];
                    }

                    if (elements[i] > maxValue)
                    {
                        maxValue = elements[i];
                    }
                }
            }

            maximumDifference = maxValue - minValue;
        }
    }
}
