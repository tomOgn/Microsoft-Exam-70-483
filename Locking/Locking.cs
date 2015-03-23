using System;
using System.Threading.Tasks;

namespace Locking
{
    public static class Example1
    {
        private static readonly object _lock = new object();
        public static int Run()
        {
            var n = 0;

            var up = Task.Run(() =>
            {
                for (var i = 0; i < 1000000; i++)
                lock (_lock)
                    n++;
            });

            for (var i = 0; i < 1000000; i++)
            lock (_lock)
                n--;

            up.Wait();

            return n;
        }
    }
}
