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
                    int size = rand.Next(0, 1000);
                    for (int i = 0; i < size; ++i)
                    {
                        arr.PushBack(rand.Next());
                    }
                    arr.Sort((x, y) => x.CompareTo(y), needReverse);
                    if (arr.IsSorted((x, y) => x.CompareTo(y), needReverse))
                    {
                        Console.WriteLine($"TestCase#{testCase} was successfully completed!");
                    }
                    else
                    {
                        throw new Exception($"TestCase#{testCase} was NOT successfully completed!");
                    }
                }
                Console.WriteLine("needReverse = " + needReverse + " was completed!");
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            Test();
        }
    }
}
