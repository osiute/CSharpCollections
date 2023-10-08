using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCollections
{
    public class Stack<T>
    {
        private const string CLASSNAME = "Stack";
        private Node<T> tail;
        public int Size { get; private set; }
        public T Top {
            get {
                if (IsEmpty()) throw new Exception($"{CLASSNAME} is empty!");
                return tail.value; 
            } 
        }

        private class Node<NestedT>
        {
            internal NestedT value;
            internal Node<NestedT> previous;
        }

        public Stack(params T[] values)
        {
            Size = 0;
            foreach (T value in values)
            {
                Push(value);
            }
        }

        public void Push(T value)
        {
            if (IsEmpty())
            {
                tail = new Node<T>
                {
                    value = value,
                    previous = null
                };
            }
            else
            {
                tail = new Node<T>
                {
                    value = value,
                    previous = tail
                };
            }
            ++Size;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception($"Attempt to pop from empty {CLASSNAME}");
            }
            T result = Top;
            tail = tail.previous;
            --Size;
            return result;
        }

        public void Clear()
        {
            Size = 0;
        }
        
        public bool IsEmpty()
        {
            return Size == 0;
        }
    }
}
