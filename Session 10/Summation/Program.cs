using System;
using System.Diagnostics;

namespace TPP.Laboratory.Concurrency.Lab10
{
    /// <summary>
    /// Clase Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Método Main
        /// </summary>
        static void Main()
        {
            const int value = 100000;

            Summation summation = new Summation(value, 1);
            Stopwatch chrono = new Stopwatch();
            chrono.Start();
            summation.Compute();
            chrono.Stop();
            Console.WriteLine("Value: {0}. Elapsed milliseconds: {1}.", summation.Value, chrono.ElapsedMilliseconds);

            summation = new Summation(value, 1000);
            chrono.Restart();
            summation.Compute();
            chrono.Stop();
            Console.WriteLine("Value: {0}. Elapsed milliseconds: {1}.", summation.Value, chrono.ElapsedMilliseconds);

            summation = new SummationLock(value, 1000);
            chrono.Restart();
            summation.Compute();
            chrono.Stop();
            Console.WriteLine("Value: {0}. Elapsed milliseconds: {1}.", summation.Value, chrono.ElapsedMilliseconds);

            summation = new SummationInterlock(value, 1000);
            chrono.Restart();
            summation.Compute();
            chrono.Stop();
            Console.WriteLine("Value: {0}. Elapsed milliseconds: {1}.", summation.Value, chrono.ElapsedMilliseconds);
        }
    }
}
