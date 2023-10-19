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
        static void Main(string[] args)
        {
            var list = new CSharpCollections.LinkedList<string>("Hello", "My", ",", "dear", "World!");
            Console.WriteLine(list);
            list.Reverse();
            Console.WriteLine(list);
            Console.WriteLine(list.IsSorted());
            list.Sort(reverse : false);
            Console.WriteLine(list.IsSorted());
            Console.WriteLine(list);
            Console.WriteLine(list.IsSorted(reverse : true));
            list.Sort(reverse : true);
            Console.WriteLine(list.IsSorted(reverse : true));
            Console.WriteLine(list);
        }
    }
}
