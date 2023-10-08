using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCollections
{
    public static class SortExtensions
    {
        public static void Sort(this DynamicArray<byte> arr, bool reverse = false)
        {
            arr.Sort((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static void Sort(this DynamicArray<SByte> arr, bool reverse = false)
        {
            arr.Sort((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static void Sort(this DynamicArray<short> arr, bool reverse = false)
        {
            arr.Sort((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static void Sort(this DynamicArray<UInt16> arr, bool reverse = false)
        {
            arr.Sort((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }

        public static void Sort(this DynamicArray<int> arr, bool reverse = false)
        {
            arr.Sort((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static void Sort(this DynamicArray<UInt32> arr, bool reverse = false)
        {
            arr.Sort((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static void Sort(this DynamicArray<long> arr, bool reverse = false)
        {
            arr.Sort((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static void Sort(this DynamicArray<UInt64> arr, bool reverse = false)
        {
            arr.Sort((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static void Sort(this DynamicArray<float> arr, bool reverse = false)
        {
            arr.Sort((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static void Sort(this DynamicArray<double> arr, bool reverse = false)
        {
            arr.Sort((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static void Sort(this DynamicArray<decimal> arr, bool reverse = false)
        {
            arr.Sort((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static void Sort(this DynamicArray<char> arr, bool reverse = false)
        {
            arr.Sort((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static void Sort(this DynamicArray<string> arr, bool reverse = false)
        {
            arr.Sort((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static bool IsSorted(this DynamicArray<byte> arr, bool reverse = false)
        {
            return arr.IsSorted((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static bool IsSorted(this DynamicArray<SByte> arr, bool reverse = false)
        {
            return arr.IsSorted((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static bool IsSorted(this DynamicArray<short> arr, bool reverse = false)
        {
            return arr.IsSorted((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static bool IsSorted(this DynamicArray<UInt16> arr, bool reverse = false)
        {
            return arr.IsSorted((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }

        public static bool IsSorted(this DynamicArray<int> arr, bool reverse = false)
        {
            return arr.IsSorted((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static bool IsSorted(this DynamicArray<UInt32> arr, bool reverse = false)
        {
            return arr.IsSorted((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static bool IsSorted(this DynamicArray<long> arr, bool reverse = false)
        {
            return arr.IsSorted((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static bool IsSorted(this DynamicArray<UInt64> arr, bool reverse = false)
        {
            return arr.IsSorted((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static bool IsSorted(this DynamicArray<float> arr, bool reverse = false)
        {
            return arr.IsSorted((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static bool IsSorted(this DynamicArray<double> arr, bool reverse = false)
        {
            return arr.IsSorted((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static bool IsSorted(this DynamicArray<decimal> arr, bool reverse = false)
        {
            return arr.IsSorted((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static bool IsSorted(this DynamicArray<char> arr, bool reverse = false)
        {
            return arr.IsSorted((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
        public static bool IsSorted(this DynamicArray<string> arr, bool reverse = false)
        {
            return arr.IsSorted((leftItem, rightItem) => leftItem.CompareTo(rightItem), reverse);
        }
    }
}
