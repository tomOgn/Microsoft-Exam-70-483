using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerable
{
    public class Enumerable1
    {
        public static void Run()
        {
	        Display(new List<bool> { true, false, true });
        }

        private static void Display(IEnumerable<bool> argument)
        {
	        foreach (var value in argument)
	            Console.WriteLine(value);
        }
    }
}
