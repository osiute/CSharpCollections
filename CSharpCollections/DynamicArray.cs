using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
