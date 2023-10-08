using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCollections
{
    internal class Node<T>
    {
        public T value;
        public Node<T> previous;

        public Node(T value, Node<T> previous)
        {
            this.value = value;
            this.previous = previous;
        }
    }

    internal class LinkedList<T>
    {
        Node<T> head;
        Node<T> tail;
        public int Size { get; private set; }
        public LinkedList(params T[] values)
        {
            if (values.Length > 0)
            {
                head = new Node<T>(values[0], null);
                Node<T> currentLast = head;
                for (int i = 1; i < values.Length; ++i)
                {
                    var newLast = new Node<T>(values[i], currentLast);
                    currentLast = newLast;
                }
            }
        }
    }

}
