using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab06 {

    /// <summary>
    /// Class showing memoization
    /// </summary>
    static class MemoizedFibonacci {

        /// <summary>
        /// To saved the values returned by the function
        /// </summary>
        private static IDictionary<int, int> values = new Dictionary<int, int>();

        /// <summary>
        /// Memoized recursive Fibonacci function
        /// </summary>
        internal static int Fibonacci(int n) {
            if (values.Keys.Contains(n))
                // * If the value was already computed, the cached value is returned
                return values[n];
            // * Otherwise, it is computed and stored
            int value =  n <= 2 ? 1 : Fibonacci(n - 2) + Fibonacci(n - 1);
            values.Add(n, value);
            return value;
        }
    }
}
