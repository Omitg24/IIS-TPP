using System.Collections.Generic;
using System;
using System.Linq;

namespace TPP.Laboratory.Functional.Lab07
{
    /// <summary>
    /// Método Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Método Main
        /// </summary>
        static void Main()
        {
            IEnumerable<int> integers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Map sin generadores
            Console.WriteLine("\nMap without generators:");
            integers.Map2(x =>
            {
                Console.Write($"{x} ");
                return x;
            });
            //Map con generadores
            Console.WriteLine("Map with generators:");
            integers.Map1(x =>
            {
                Console.Write($"{x} ");
                return x;
            }).Last();            
            //ForEach
            Console.WriteLine("\nForEach:");
            integers.ForEach(x => Console.Write($"{x} "));
        }
    }
}
