using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using CSharpCollections;

namespace Test
{
    internal class Program
    {
        static void TestDynamicArray()
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
            var list = new CSharpCollections.LinkedList<int>(-8, 432, 89, -7, 8, -8, -8, 4238, -8, 4832791, -0, 0, -8);
            Console.WriteLine("The length of linked list is " + list.Size);
            list.DeleteItems(-8, 4);
            foreach(int num in list)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine(list);
        }
    }
}
