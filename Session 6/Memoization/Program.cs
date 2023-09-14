using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TPP.Laboratory.Functional.Lab06 {

    /// <summary>
    /// Ejemplo de memorización
    /// </summary>
    class Program {

        /// <summary>
        /// Método Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            const int fibonacciTerm = 40;
            int result;

            var chrono = new Stopwatch();
            chrono.Start();
            result = NonMemoizedFibonacci.Fibonacci(fibonacciTerm);
            chrono.Stop();
            long firstCallNonMemoized = chrono.ElapsedTicks;
            Console.WriteLine("Non memoized version. First invocation in {0:N} ticks. Result: {1}.", firstCallNonMemoized, result);

            chrono.Restart();
            result = NonMemoizedFibonacci.Fibonacci(fibonacciTerm);
            chrono.Stop();
            long secondCallNonMemoized = chrono.ElapsedTicks;
            Console.WriteLine("Non memoized version. Second invocation in {0:N} ticks. Result: {1}.", secondCallNonMemoized, result);

            chrono.Restart();
            result = MemoizedFibonacci.Fibonacci(fibonacciTerm);
            chrono.Stop();
            long firstCallMemoized = chrono.ElapsedTicks;
            Console.WriteLine("Memoized version. First invocation in {0:N} ticks. Result: {1}.", firstCallMemoized, result);

            chrono.Restart();
            result = MemoizedFibonacci.Fibonacci(fibonacciTerm);
            chrono.Stop();
            long secondCallMemoized = chrono.ElapsedTicks;
            Console.WriteLine("Memoized version. Second invocation in {0:N} ticks. Result: {1}.", secondCallMemoized, result);
        }


    }
}
