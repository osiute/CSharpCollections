using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCollections;

namespace Tets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stringArray = Console.ReadLine().Split();
            var arr = new DynamicArray<string>(stringArray);

            while (arr.Size != 10)
            {
                arr.InsertAfter(0, Console.ReadLine());
                Console.WriteLine(arr);
            }
            
        }
    }
}
