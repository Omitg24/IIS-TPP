using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab06 {

    static class Fibonacci {

        /// <summary>
        /// Método InfiniteFibonacci
        /// </summary>
        /// <returns></returns>
        static internal IEnumerable<int> InfiniteFibonacci() {
            int first = 1, second = 1;
            while (true) {
                yield return first;
                int addition = first + second;
                first = second;
                second = addition;
            }
        }

        /// <summary>
        /// Método FiniteFibonacci
        /// </summary>
        /// <param name="maxTerm"></param>
        /// <returns></returns>
        static internal IEnumerable<int> FiniteFibonacci(int maxTerm)
        {
            int first = 1, second = 1, term = 1;
            while (true)
            {
                yield return first;
                int addition = first + second;
                first = second;
                second = addition;                
                if (term == maxTerm)
                {
                    yield break;
                }
                term++;
            }
        }

        /// <summary>
        /// Método FibonacciLazy
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        static internal IEnumerable<int> FibonacciLazy(int from, int to)
        {
            return InfiniteFibonacci().Skip(from - 1).Take(to - from);
        }

        /// <summary>
        /// Método FibonacciEager
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        static internal IEnumerable<int> FibonacciEager(int from, int to)
        {
            int first = 1, second = 1, term = 1;
            List<int> fibonacciList = new List<int>();
            while (true)
            {
                if (term >= from)
                {
                    fibonacciList.Add(first);
                }
                int addition = first + second;
                first = second;
                second = addition;                
                if (term == to)
                {
                    break;
                }
                term++;
            }
            return fibonacciList;
        }
    }
}
