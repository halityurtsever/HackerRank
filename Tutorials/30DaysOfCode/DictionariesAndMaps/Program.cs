using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionariesAndMaps
{
    class Program
    {
        static void Main(string[] args)
        {
            var arraySize = Convert.ToInt32(Console.ReadLine());

            //construct array
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            for (int i = 0; i < arraySize; i++)
            {
                var phoneData = Console.ReadLine().Split(' ');
                var name = phoneData[0];
                var phone = phoneData[1];

                phoneBook.Add(name, phone);
            }

            //query names
            for (int i = 0; i < arraySize; i++)
            {
                var queryData = Console.ReadLine();

                if (phoneBook.ContainsKey(queryData))
                {
                    var phoneNumber = phoneBook[queryData];
                    Console.WriteLine($"{queryData}={phoneNumber}");
                }
                else
                {
                    Console.WriteLine("Not found");
                }
            }
        }
    }
}
