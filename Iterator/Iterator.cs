using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Iterator
{
    public static class Example1
    {
        public static void Run()
        {
            foreach (var i in Power(2, 8))
                Console.Write("{0} ", i);
        }

        private static IEnumerable<int> Power(int number, int exponent)
        {
            var result = 1;

            for (var i = 0; i < exponent; i++)
            {
                result *= number;
                yield return result;
            }
        }
    }

    public static class Example2
    {
        public static void Run()
        {
            var theGalaxies = new Galaxies();
            foreach (var theGalaxy in theGalaxies.NextGalaxy)
                Debug.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears);
        }

        public class Galaxies
        {
            public IEnumerable<Galaxy> NextGalaxy
            {
                get
                {
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                }
            }

        }

        public class Galaxy
        {
            public String Name { get; set; }
            public int MegaLightYears { get; set; }
        }
    }


}
