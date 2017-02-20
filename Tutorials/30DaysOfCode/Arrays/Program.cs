using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var arraySize = Convert.ToInt32(Console.ReadLine());
            var arrayItem = Console.ReadLine().Split(' ');

            for (int i = arraySize -1; i >= 0; i--)
            {
                Console.Write(arrayItem[i] + " ");
            }
        }
    }
}
