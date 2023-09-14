using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace TPP.Laboratory.Concurrency.Lab10
{
    /// <summary>
    /// Clase Summation
    /// </summary>
    internal class Summation
    {
        /// <summary>
        /// Atributo value
        /// </summary>
        protected long value;

        /// <summary>
        /// Atributo numberOfThreads
        /// </summary>
        private int numberOfThreads;

        /// <summary>
        /// Atributo vector
        /// </summary>
        private IEnumerable<int> vector;

        /// <summary>
        /// Propiedad Value
        /// </summary>
        internal long Value { get { return value; }}
        
        internal Summation(int elements, int numberOfThreads)
        {
            if (numberOfThreads > elements)
            {
                throw new ArgumentException("The number of threads is too high");
            }
            this.numberOfThreads = numberOfThreads;
            vector = Enumerable.Range(1, elements);
        }

        /// <summary>
        /// Método Add
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <exception cref="ArgumentException"></exception>
        protected virtual void Add(IEnumerable<int> collection, int from, int to)
        {
            if (from > to)
            {
                throw new ArgumentException("From cannot be greater than to");
            }
            this.value = Value + collection.Skip(from).Take(to - from + 1).Aggregate(0L, (a, b) => a + b);
        }

        /// <summary>
        /// Método Compute
        /// </summary>
        /// <returns></returns>
        internal long Compute()
        {
            int elementsPerThread = vector.Count() / numberOfThreads;
            Thread[] threads = new Thread[numberOfThreads];
            for (int i = 0; i < numberOfThreads; i++)
            {
                threads[i] = new Thread((object iObj) =>
                {
                    int i = (int)iObj;
                    this.Add(this.vector, i * elementsPerThread,
                        i < numberOfThreads - 1 ? // last iteration
                        (i + 1) * elementsPerThread - 1 :
                        vector.Count() - 1);
                });
            }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start(i);
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }                
            return Value;
        }       
    }

    /// <summary>
    /// Clase SummationLock
    /// </summary>
    internal class SummationLock : Summation
    {
        /// <summary>
        /// Atributo monitor
        /// </summary>
        private object monitor = new object();

        /// <summary>
        /// Constructor SummationLock
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="numberOfThreads"></param>
        internal SummationLock(int elements, int numberOfThreads) : base(elements, numberOfThreads) { }

        /// <summary>
        /// Método Add
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <exception cref="ArgumentException"></exception>
        protected override void Add(IEnumerable<int> collection, int from, int to)
        {
            if (from > to)
            {
                throw new ArgumentException("From cannot be greater than to");
            }
            lock (monitor)
            {
                this.value = Value + collection.Skip(from).Take(to - from + 1).Aggregate(0L, (a, b) => a + b);
            }
        }
    }

    /// <summary>
    /// Clase SummationInterlock
    /// </summary>
    internal class SummationInterlock : Summation
    {
        /// <summary>
        /// Constructor SummationInterlock
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="numberOfThreads"></param>
        internal SummationInterlock(int elements, int numberOfThreads) : base(elements, numberOfThreads) { }

        protected override void Add(IEnumerable<int> collection, int from, int to)
        {
            Interlocked.Add(ref this.value, collection.Skip(from).Take(to - from + 1).Aggregate(0L, (a, b) => a + b));
        }
    }
}
