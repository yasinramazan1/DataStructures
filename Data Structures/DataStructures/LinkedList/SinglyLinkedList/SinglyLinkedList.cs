using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedListNode<T> head { get; set; }
        private bool isHeadNull => head == null;
        public void addFirst(T value)
        {
            // Başa eleman ekleme metodu 
            var newNode = new SinglyLinkedListNode<T>(value);
            newNode.next = head;
            head = newNode;
        }

        public void addLast(T value)
        {
            // Sona eleman ekleme metodu
            var newNode = new SinglyLinkedListNode<T>(value);

            if (isHeadNull)
            {
                head = newNode;
                return;
            }

            var current = head;
            while (current.next != null)
            {
                // Bu bölüm karmaşıklığı arttıran bölümdür diyebiliriz.
                current = current.next;
            }
            current.next = newNode;
        }

        public void addAfter(SinglyLinkedListNode<T> node, T value)
        {
            if(node == null)
            {
                throw new ArgumentNullException();
            }

            if (isHeadNull)
            {
                addFirst(value);
                return;

            }
            var newNode = new SinglyLinkedListNode<T>(value);
            var current = head;
            while (current != null)
            {
                if (current.Equals(node))
                {
                    newNode.next = current.next;
                    current.next = newNode;
                    return;
                }
                current = current.next;
            }
            throw new ArgumentException("The refernce node is not in this list.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
