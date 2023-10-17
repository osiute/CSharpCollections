using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCollections
{
    public partial class LinkedList<T>
    {
        private class LinkedListEnumerator : IEnumerator<T>
        {
            public LinkedListEnumerator(LinkedList<T> list)
            {
                this.list = list;
                Reset();
            }

            private LinkedList<T> list;

            private bool wasStarted;

            private Node<T> currentNode;

            public T Current => currentNode.value;

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (!wasStarted)
                {
                    currentNode = list.head;
                    wasStarted = true;
                }
                else
                {
                    currentNode = currentNode.next;
                }
                return currentNode != null;
            }

            public void Reset()
            {
                wasStarted = false;
                currentNode = null;
            }

            public void Dispose()
            {
            }
        }
    }
}
