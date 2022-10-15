using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedListNode<T> // T kavramı hangi tip üzerinde çalışacağımıza çalışma zamanında karar vermemizi sağlayan generic yapıdır.
    {
        public SinglyLinkedListNode<T> next { get; set; }
        public T value { get; set; }

        public SinglyLinkedListNode(T value)
        {
            // Bu yapıcı metota girilen parametre aslında bu sınıfın new'lendiğinde yapıcısında alacağı parametre olmuş oluyor.
            this.value = value;
        }

        //public override string ToString()
        //{
        //    return $"{value}";
        //}

        public override string ToString() => $"{value}"; // Bu kullanım lambda ifadesidir.
    }
}
