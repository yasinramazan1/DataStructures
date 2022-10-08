



using System.Collections;
using System.Linq;

namespace Apps
{
    class Program
    {
        static void Main(string[] args)
        {
            //var p1 = new DataStructures.Array.Array<int>(1,2,3,4);
            //var p2 = new int[] { 5, 6, 7, 8 };
            //var p3 = new List<int>() { 9, 10, 11, 12 };
            //var p4 = new ArrayList() { 13, 14, 15, 16 }; // ArrayList'i parametre olarak döngüye veremeyiz çünkü IEnumerable yapısı tip güvenliği sağlıyor.


            //var arr = new DataStructures.Array.Array<int>();
            //for (int i = 0; i < 8; i++)
            //{
            //    arr.add(i + 1);
            //    Console.WriteLine($"{i+1} has been added to array.");
            //    Console.WriteLine($"{arr.Count}/{arr.Capacity}");
            //}

            //Console.WriteLine(); 

            //for (int i = arr.Count; i >= 1; i--)
            //{
            //    Console.WriteLine($"{arr.remove()} has been removed from the array.");
            //    Console.WriteLine($"{arr.Count}/{arr.Capacity}");
            //}
            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}

            var arr = new DataStructures.Array.Array<int>(1,3,5,7);
            // var crr = (DataStructures.Array.Array<int>)arr.Clone();
            var crr = arr.Clone() as DataStructures.Array.Array<int>;

            arr.add(89); // Klonlanmış nesne ile ilk nesne arasında referans ilişkisi olmadığı için değişiklikler o nesne ile sınırlı kalacaktır.
            // deep copy'de nesne sıfırdan oluşturulur ancak yine referans yoktur.
            foreach (var item in arr)
            {
                Console.Write($"{item, -3}");
            }
            Console.WriteLine($"{arr.Count}/{arr.Capacity}");

            Console.WriteLine();           

            foreach (var item in crr)
            {
                Console.Write($"{item,-3}");
            }
            Console.WriteLine($"{crr.Count}/{crr.Capacity}");

            Console.ReadKey();
        }

        /* void diziIslemleri()
        {
            arr.add(1);
            arr.add(2);
            arr.add(3);
            arr.add(4);
            arr.add(5);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------");
            arr.Where(x => x % 2 == 0).ToList().ForEach(x => Console.WriteLine(x)); // ikiye bölünebilen elemanları filtreler.
            Console.WriteLine($"{arr.Count}/{arr.Capacity}");
        }
        */

        void Bilgiler()
        {
            // Array 
            var arrayChar = new char[] { 'y', 'r', 'g' }; // Bu dizi sabit boyutludur.
            var arrayInt = Array.CreateInstance(typeof(int), 5);
            arrayInt.SetValue(8, 0); // arrayInt[0] = 8 değerini atar.
            arrayInt.GetValue(0); // 0. indexteki elemanı döndürür. Yani 8 
            Console.WriteLine(arrayInt.Length);


            // ArrayList 
            // Dizi üzerinde yönetimsel fonksiyonlara ihtiyaç duyulduğunda Array yerine ArrayList kullanılmalıdır.
            // type-safe yoktur.
            // 5 -> boxing -> object
            // a -> boxing -> object
            // object -> unboxing - int
            var arrayObj = new ArrayList();
            arrayObj.Add(5);
            arrayObj.Add('a');
            Console.WriteLine(arrayObj.Count);

            // List<T> 
            // Genelde işlem yapılan veri yapıları koleksiyon türüne indirgenerek tanımlanır.
            var arrInt = new List<int>();
            arrInt.Add(10);
            arrInt.AddRange(new int[] { 1, 2, 3 });
            arrInt.RemoveAt(0);
            Console.WriteLine(arrInt.Count);
            foreach (var item in arrInt)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}