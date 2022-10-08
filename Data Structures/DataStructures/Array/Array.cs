using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Array
{
    public class Array<T> :  IEnumerable<T>,ICloneable // <T> şeklinde tanımlamakla birlikte tip güvenliğini sağlıyoruz ve boxing-unboxing işlemlerine gerek kalmıyor.
    {
        // IEnumerable yapısı GetEnumerator'ı garanti ettiği için foreach döngüsünü rahatlıkla kullanabiliyoruz.
        // IEnumerable<T> ile koleksiyonu numaralandırılabilir bir yeteneğe kavuşturmuş oluyoruz.
        // Aynı zamanda dile entegre sorguları da çalıştırabiliyoruz. ( LINQ = Language INtegrated Query)
        // IEnumerable<T> ifadesi ile koleksiyondan her defasında bir örnek seçip kullanabilme imkanı sağlamaktadır. Yani kısaca numaralandırma işlemi yapmamızı sağlamaktadır.
        private T[] InnerList;

        public int Count { get; private set; }
        public int Capacity => InnerList.Length;

        public Array()
        {
            InnerList = new T[2];
            Count = 0;
        }

        public Array(params T[] initial)
        {
            InnerList = new T[initial.Length];
            Count = 0;
            foreach(var item in initial)
            {
                add(item); 
            }
        }

        public Array(IEnumerable<T> collection)
        {
            InnerList = new T[collection.ToArray().Length];
            Count = 0;
            foreach(var item in collection)
            {
                add(item);
            }
        }

        public void add(T item)
        {
            if (InnerList.Length == Count)
            {
                doubleArray();
            }
            InnerList[Count] = item;
            Count++;
        }

        private void doubleArray()
        {
            var temp = new T[InnerList.Length * 2];
            /*
            for (int i = 0; i < InnerList.Length; i++)
            {
                temp[i] = InnerList[i];
            }
            */
            System.Array.Copy(InnerList, temp, InnerList.Length);
            InnerList = temp;
        }

        public T remove()
        {
            if (Count == 0)
            {
                throw new Exception("There is no more item to be removed from the array.");
            }

            if (InnerList.Length / 4 == Count)
            {
                halfArray();
            }
            var temp = InnerList[Count - 1];
            if (Count > 0)
            {
                Count--;
            }
            return temp;
        }

        private void halfArray()
        {
            if (InnerList.Length > 2)
            {
                var temp = new T[InnerList.Length / 2];
                System.Array.Copy(InnerList,temp,InnerList.Length/4);
                InnerList = temp;
            }
        }

        public object Clone()
        {
            //return this.MemberwiseClone(); // Sığ copy 
            
            // deep copy
            var arr = new Array<T>();
            foreach (var item in this)
            {
                arr.add(item);
            }
            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InnerList.Select(x => x).GetEnumerator();
            // return InnerList.Take(Count).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        
    }
}
