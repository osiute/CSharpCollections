using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCollections
{
    public class LinkedList<T>
    {
        private const string CLASSNAME = "LinkedList";
        Node<T> head;
        Node<T> tail;
        public int Size { get; private set; }

        public LinkedList(params T[] values)
        {
            Size = 0;
            foreach (T value in values)
            {
                PushTail(value);
            }
        }

        public void PushTail(T value)
        {
            if (IsEmpty()) _SetStartValue(value);
            else _SetNewTail(value);
        }

        public void PushHead(T value)
        {
            if (IsEmpty()) _SetStartValue(value);
            else _SetNewHead(value);
        }

        public T PopTail()
        {
            _RaiseErrorIfEmpty();
            T result = tail.value;
            tail = tail.previous;
            --Size;
            return result;
        }

        public T PopHead()
        {
            _RaiseErrorIfEmpty();
            T result = head.value;
            head = head.next;
            --Size;
            return result;
        }

        public void Clear()
        {
            Size = 0;
        }

        public bool IsEmpty()
        {
            return (Size == 0);
        }

        private void _SetStartValue(T value)
        {
            tail = head = new Node<T>
            {
                previous = null,
                value = value,
                next = null
            };
            ++Size;
        }

        private void _SetNewTail(T value)
        {
            var newTail = new Node<T>
            {
                previous = tail,
                value = value,
                next = null
            };
            tail.next = newTail;
            tail = newTail;
            ++Size;
        }

        private void _SetNewHead(T value)
        {
            var newHead = new Node<T>
            {
                previous = tail,
                value = value,
                next = head
            };
            head.previous = newHead;
            head = newHead;
            ++Size;
        }

        private void _RaiseErrorIfEmpty()
        {
            if (IsEmpty())
            {
                throw new DeleteFromEmptyListException($"Attempt to delete from empty {CLASSNAME}");
            }
        }
        
        private class Node<NestedT>
        {
            public Node<NestedT> previous;
            public NestedT value;
            public Node<NestedT> next;
        }

        private class DeleteFromEmptyListException : Exception
        {
            public DeleteFromEmptyListException(string message) : base(message) { }
        }
    }
}
