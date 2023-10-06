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
        static bool srtrule(object left, object right)
        {
            return (double)left > (double)right;
        }

        static void Main(string[] args)
        {
            var arr = new DynamicArray<double>(-87432, -74, 1, 2, 3, 8, 4, 5, 6, 7, 8);
            arr.Reverse();
            Console.WriteLine(arr);
        }
    }
}
