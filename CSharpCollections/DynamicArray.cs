using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpCollections
{
    public class DynamicArray<T>
    {
        private T[] _internalArray;
        public int Size { get; private set; }

        public DynamicArray(params T[] values)
        {
            Size = values.Length;
            if (values.Length == 0)
            {
                _CreateNewInternalArray();
                return;
            }
            _internalArray = values;
        }

        public override string ToString()
        {
            string result = "{";
            for (int i = 0; i < Size; ++i)
            {
                string postfix = i == Size - 1 ? "" : ", ";
                result += $"{_internalArray[i]}{postfix}";
            }
            return result + "}";
        }

        public T this[int index]
        {
            get
            {
                _CheckIndexOrError(ref index);
                return _internalArray[index];
            }
            set
            {
                _CheckIndexOrError(ref index);
                _internalArray[index] = value;
            }
        }

        public void PushBack(T item)
        {
            if (_IsInternalFull())
            {
                _ExpandInternalArray();
            }
            _internalArray[Size++] = item;
        }

        public T PopBack()
        {
            if (IsEmpty())
            {
                throw new Exception("Delete from empty dynamic array attempt.");
            }
            return _internalArray[--Size];
        }

        public T DeleteAndGetItem(int index)
        {
            CyclicShift(from: index, to: -1);
            return PopBack();
        }

        public void DeleteAllItemsWithValue(T value)
        {
            DeleteCertainItemsWithValue(value, Size);
        }

        public void DeleteCertainItemsWithValue(T value, int repeats)
        {
            if (repeats <= 0) return;
            int count = 0;
            int start = 0;
            for (int i = 0; i < Size; ++i)
            {
                if (_internalArray[i].Equals(value))
                {
                    start = i;
                    break;
                }
            }
            for (int i = start; i < Size; ++i)
            {
                if (_internalArray[i].Equals(value) && count < repeats)
                {
                    count += 1;
                }
                else
                {
                    _internalArray[i - count] = _internalArray[i];
                }
            }
            Size -= count;
        }

        public void MakeEmpty()
        {
            Size = 0;
        }

        public void Clear()
        {
            MakeEmpty();
            _CreateNewInternalArray();
        }

        public void InsertAfter(int index, T item)
        {
            PushBack(item);
            CyclicShift(-1, index + 1);
        }
        
        public void InsertBefore(int index, T item)
        {
            PushBack(item);
            CyclicShift(-1, index);
        }

        public void SwapItems(int i, int j)
        {
            _CheckIndexOrError(ref i);
            _CheckIndexOrError(ref j);
            T temp = _internalArray[i];
            _internalArray[i] = _internalArray[j];
            _internalArray[j] = temp;
        }
        
        public void CyclicShift(int from, int to)
        {
            _CheckIndexOrError(ref from);
            _CheckIndexOrError(ref to);
            int k = from > to ? -1 : +1;
            for (; from != to; from += k)
            {
                SwapItems(from, from + k);
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < Size / 2; ++i)
            {
                SwapItems(i, -1 - i);
            }
        }
        
        public bool IsSorted(Comparison<T> comparison, bool needReverse = false)
        {
            int k = needReverse ? -1 : 1;
            for (int i = 1; i < Size; ++i)
            {
                T leftItem = _internalArray[i - 1];
                T rightItem = _internalArray[i];
                if (_IsIncorrectOrder(leftItem, rightItem, comparison, k))
                {
                    return false;
                }
            }
            return true;
        }

        public void Sort(Comparison<T> comparison, bool needReverse = false)
        {
            _Sort(leftIndex: 0, rightIndex: Size - 1,
                comparison: comparison, needReverse: needReverse);
        }

        private void _Sort(int leftIndex, int rightIndex, 
            Comparison<T> comparison, bool needReverse = false)
        {
            if (leftIndex >= rightIndex) return;
            int border = _ScatterItemsForSort(leftIndex, rightIndex, comparison, needReverse);
            _Sort(leftIndex, border - 1, comparison, needReverse);
            _Sort(border, rightIndex, comparison, needReverse);
        }

        private int _ScatterItemsForSort(int i, int j,
            Comparison<T> comparison, bool needReverse = false)
        {
            int k = needReverse ? -1 : 1;
            T pivot = _internalArray[(i + j) / 2];
            while(i <= j)
            {
                while (_IsIncorrectOrder(pivot, _internalArray[i], comparison, k)) ++i;
                while (_IsIncorrectOrder(_internalArray[j], pivot, comparison, k)) --j;
                if (i <= j)
                {
                    SwapItems(i++, j--);
                }
            }
            return i;
        }

        private bool _IsIncorrectOrder(T leftItem, T rightItem,
            Comparison<T> comparison, int k)
        {
            return comparison(leftItem, rightItem) * k > 0;
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        private bool _IsInternalFull()
        {
            return Size == _internalArray.Length;
        }

        private void _CheckIndexOrError(ref int index)
        {
            if (index < 0) index = Size + index;
            if (index < 0 || index >= Size)
                throw new IndexOutOfRangeException($"Dynamic array index out of range.({index})");
        }

        private void _ExpandInternalArray()
        {
            var newArray = new T[_internalArray.Length * 3];
            for (int i = 0; i < Size; ++i)
            {
                newArray[i] = _internalArray[i];
            }
            _internalArray = newArray;
        }

        private void _CreateNewInternalArray()
        {
            _internalArray = new T[10];
        }
    }
}
