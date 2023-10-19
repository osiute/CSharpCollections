using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCollections
{
    public partial class LinkedList<T> : IEnumerable<T>
    {
        Node<T> head;
        Node<T> tail;
        public int Size { get; protected set; }

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
            if (tail != null) tail.next = null;
            else Clear();
            --Size;
            return result;
        }

        public T PopHead()
        {
            _RaiseErrorIfEmpty();
            T result = head.value;
            head = head.next;
            if (head != null) head.previous = null;
            else Clear();
            --Size;
            return result;
        }

        public void Reverse()
        {
            Node<T> leftNode = head, rightNode = tail;
            for (int i = 0; i < Size / 2; ++i)
            {
                SwapValues(leftNode, rightNode);
                leftNode = leftNode.next;
                rightNode = rightNode.previous;
            }
        }

        public void Sort(Comparison<T> comparison, bool reverse = false)
        {
            if (Size <= 1) return;
            int leftIndex = 0, rightIndex = Size - 1;
            Node<T> leftItem = head; Node<T> rightItem = tail;
            QuickSort(leftIndex, leftItem, rightIndex, rightItem, comparison, reverse);
        }

        private void QuickSort(int leftIndex, Node<T> leftItem, int rightIndex, Node<T> rightItem,
            Comparison<T> comparison, bool reverse)
        {
            if (leftIndex >= rightIndex) return;
            int sign = reverse ? -1 : +1;
            int i = leftIndex, j = rightIndex;
            Node<T> pivotNode = leftItem, comparitionNode = rightItem;
            while (i < j)
            {
                T pivot = pivotNode.value, comparitionValue = comparitionNode.value;
                if (comparison(pivot, comparitionValue) * sign > 0)
                {
                    SwapValues(pivotNode, comparitionNode);
                    SwapValues(comparitionNode, pivotNode.next);
                    pivotNode = pivotNode.next;
                    ++i;
                }
                else
                {
                    comparitionNode = comparitionNode.previous;
                    --j;
                }
            }
            QuickSort(leftIndex, leftItem, i - 1, pivotNode.previous, comparison, reverse);
            QuickSort(i + 1, pivotNode.next, rightIndex, rightItem, comparison, reverse);
        }
        
        private void SwapValues(Node<T> node1, Node<T> node2)
        {
            T temp = node1.value;
            node1.value = node2.value;
            node2.value = temp;
        }

        public void DeleteAllItemsWithValue(T value)
        {
            Node<T> currentNode = head;
            while (currentNode != null)
            {
                var nextNode = currentNode.next;
                if (currentNode.value.Equals(value))
                {
                    DeleteNode(currentNode);
                }
                currentNode = nextNode;
            }
        }

        /// <summary>
        /// This method deletes items a certain count of times with certain value.
        /// </summary>
        /// <param name="value">The value of items you want to delete.</param>
        /// <param name="repeats">The number of items you want to delete.</param>
        /// <returns>bool value to return(exactly {repeats} items was deleted).</returns>
        public bool DeleteItems(T value, int repeats = 1)
        {
            if (repeats < 0)
            {
                throw new Exception($"Arg repeats in DeleteItems can't be negative ({repeats})");
            }
            Node<T> currentNode = head;
            while (currentNode != null)
            {
                if (repeats == 0) return true;
                var nextNode = currentNode.next;
                if (currentNode.value.Equals(value))
                {
                    DeleteNode(currentNode);
                    repeats--;
                }
                currentNode = nextNode;
            }
            return repeats == 0;
        }

        public void Clear()
        {
            tail = head = null;
            Size = 0;
        }

        public bool IsSorted(Comparison<T> comparison, bool reverse = false)
        {
            Node<T> currentNode = head;
            int sign = reverse ? -1 : +1;
            for (int i = 1; i < Size; ++i)
            {
                T currentValue = currentNode.value;
                T nextValue = currentNode.next.value;
                if (comparison(currentValue, nextValue) * sign > 0)
                {
                    return false;
                }
                currentNode = currentNode.next;
            }
            return true;
        }

        public bool IsEmpty()
        {
            return (Size == 0);
        }

        public override string ToString()
        {
            string result = "{";
            Node<T> currentNode = head;

            for (int i = 0; i < Size; ++i)
            {
                string postfix = i == Size - 1 ? "" : ", ";
                result += Convert.ToString(currentNode.value) + postfix;
                currentNode = currentNode.next;
            }

            return result + "}";
        }

        protected void _SetStartValue(T value)
        {
            tail = head = new Node<T>
            {
                previous = null,
                value = value,
                next = null
            };
            ++Size;
        }

        protected void _SetNewTail(T value)
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

        protected void _SetNewHead(T value)
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

        protected void _RaiseErrorIfEmpty()
        {
            if (IsEmpty())
            {
                RaiseEmptyDeleteException();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected void DeleteNode(Node<T> node)
        {
            if (IsEmpty())
                RaiseEmptyDeleteException();

            if (Size == 1)
            {
                Clear();
                return;
            }
            if (node.previous != null)
                node.previous.next = node.next;
            else
                head = node.next;
            if (node.next != null)
                node.next.previous = node.previous;
            else
                tail = node.previous;
            Size--;
        }

        protected class Node<NestedT>
        {
            public Node<NestedT> previous;
            public NestedT value;
            public Node<NestedT> next;
        }

        protected void RaiseEmptyDeleteException()
        {
            throw new DeleteFromEmptyListException($"Attempt to delete from empty {this.GetType().Name}");
        }

        protected class DeleteFromEmptyListException : Exception
        {
            public DeleteFromEmptyListException(string message) : base(message) { }
        }
    }
}
