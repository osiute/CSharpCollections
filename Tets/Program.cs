using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using CSharpCollections;

namespace Tets
{
    internal class Program
    {
        static void Test()
        {
            var arr = new DynamicArray<int>();
            Random rand = new Random();
            foreach (bool needReverse in new bool[] { false, true })
            {
                for (int testCase = 1; testCase <= 200; ++testCase)
                {
                    int size = rand.Next(0, (int)Math.Pow(10, 5));
                    for (int i = 0; i < size; ++i)
                    {
                        arr.PushBack(rand.Next());
                    }
                    arr.Sort(needReverse);
                    if (arr.IsSorted(needReverse))
                    {
                        Console.WriteLine($"TestCase#{testCase} was successfully completed!");
                    }
                    else
                    {
                        throw new Exception($"TestCase#{testCase} was NOT successfully completed!");
                    }
                    arr.MakeEmpty();
                }
                Console.WriteLine("needReverse = " + needReverse + " was completed!");
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            var arr = new DynamicArray<string>(Console.ReadLine().Split());
            Console.WriteLine(arr.IsSorted());
            arr.Sort();
            Console.WriteLine(arr);
            Console.WriteLine(arr.IsSorted());
        }
    }
}
