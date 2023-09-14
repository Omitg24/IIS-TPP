using System;
using System.Diagnostics;
using System.Linq;

namespace TPP.Laboratory.Functional.Lab06 {
    
    /// <summary>
    /// Clase Program
    /// </summary>
    class Program {
        static void Main() {
            int i = 0;
            Stopwatch chrono = new Stopwatch();

            //Fibonacci infinito (yield return)
            Console.WriteLine("InfiniteFibonacci");
            foreach (int value in Fibonacci.InfiniteFibonacci()) {
                Console.Write(value + " ");
                if (++i == 10)
                    break;
            }
            Console.WriteLine();

            //Fibonacci finito (yield return y yield break)
            Console.WriteLine("\nFiniteFibonacci");
            foreach (int value in Fibonacci.FiniteFibonacci(10)) {
                Console.Write(value + " ");
            }
            Console.WriteLine();

            //Fibonacci finito con Take
            //int counter = 1;
            //foreach (int value in Fibonacci.FiniteFibonacci(500).Take(20))
            //{
            //    Console.WriteLine($"Term: {counter} {value} ");
            //    counter++;
            //}
            //Console.WriteLine();

            //Fibonacci Lazy (utiliza el infinito y Skip y Take)            
            Console.WriteLine("\nFibonacciLazy");
            chrono.Start();
            foreach (int value in Fibonacci.FibonacciLazy(0, 10))
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
            chrono.Stop();
            long elapsedTicksLazy = chrono.ElapsedTicks;
                        
            //Fibonacci Eager (utiliza una lista y calcula todos los elementos hasta llegar hasta donde empezar)
            Console.WriteLine("\nFibonacciEager");
            chrono.Reset();
            chrono.Start();
            foreach (int value in Fibonacci.FibonacciEager(1000, 1500))
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
            chrono.Stop();
            long elapsedTicksEager = chrono.ElapsedTicks;

            //Mostrar la medición de tiempos
            Console.WriteLine($"\n\tTicks passed with FibonacciLazy: {elapsedTicksLazy}");
            Console.WriteLine($"\n\tTicks passed with FibonacciEager: {elapsedTicksEager}");
            Console.WriteLine($"\n\tLazy is {(double) elapsedTicksEager/elapsedTicksLazy} times faster than Eager");
        }
    }
}
