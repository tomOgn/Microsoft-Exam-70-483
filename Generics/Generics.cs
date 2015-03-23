using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Generics
{
    public class ItemList<T>
    {
        private const uint size = 10;
        private readonly T[] items = new T[size];
        private uint count;
        public void Add(T item)
        {
            if (count >= size) return;
            items[count] = item;
            count++;
        }
        public T this[int index]
        {
            get { return items[index]; }
        }
    }

    public static class Test
    {
        public static void T1()
        {
            var list1 = new ItemList<int>();
            var list2 = new ItemList<string>();

            list1.Add(5);
            list1.Add(10);
            Console.WriteLine(list1[1]);

            list2.Add("The");
            list2.Add("Walking");
            list2.Add("Dead");
            var sentence = "";
            for (var i = 0; i < 3; ++i)
                sentence += list2[i] + " ";
            Console.WriteLine(sentence);
        }
    }
}
