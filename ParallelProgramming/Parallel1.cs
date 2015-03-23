using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel
{
    public static class Invoke1
    {
        private static int F(int n)
        {
            var count = 0;
            for (var i = 0; i < n; ++i)
                for (var j = 0; j < n; ++j)
                    count++;
            return count;
        }
        private static void F1()
        {
            Console.WriteLine("F1 finished. Cost = " + F(1000) + " computations.");
        }
        private static void F2()
        {
            Console.WriteLine("F2 finished. Cost = " + F(2000) + " computations.");
        }
        private static void F3()
        {
            Console.WriteLine("F3 finished. Cost = " + F(3000) + " computations.");
        }
        public static void Test()
        {
            Console.WriteLine("Executing F3, F2, F1 in parallel...");
            System.Threading.Tasks.Parallel.Invoke(F3, F2, F1);
        }
    }

    public static class For
    {
        public static void Test1()
        {
            System.Threading.Tasks.Parallel.For(0, 100, Console.WriteLine);
        }
        public static void Test2()
        {
            System.Threading.Tasks.Parallel.For(0, 100, (i, state) =>
            {
                Console.WriteLine(i);
                if (i == 50) state.Stop();
            });
        }
        public static void Test3()
        {
            System.Threading.Tasks.Parallel.For(0, 100, (i, state) =>
            {
                Console.WriteLine(i);
                if (i == 50) state.Break();
            });
        }
    }

    public static class ForEach
    {
        public static void Test1()
        {
            var enumeration = Enumerable.Range(0, 100);
            System.Threading.Tasks.Parallel.ForEach(enumeration, Console.WriteLine);
        }
    }
}
