using System;
using System.Threading;

namespace TPP.Laboratory.Concurrency.Lab09 
{
    /// <summary>
    /// Clase Master
    /// </summary>
    public class Master {

        /// <summary>
        /// Atributo vector
        /// </summary>
        private short[] vector;

        /// <summary>
        /// Atributo numberOfThreads
        /// </summary>
        private int numberOfThreads;

        /// <summary>
        /// Constructor Master
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="numberOfThreads"></param>
        /// <exception cref="ArgumentException"></exception>
        public Master(short[] vector, int numberOfThreads) {
            if (numberOfThreads < 1 || numberOfThreads > vector.Length)
                throw new ArgumentException("The number of threads must be lower or equal to the number of elements in the vector.");
            this.vector = vector;
            this.numberOfThreads = numberOfThreads;
        }

        /// <summary>
        /// Método ComputeModulus
        /// </summary>
        /// <returns></returns>
        public double ComputeModulus() {
            Worker[] workers = new Worker[this.numberOfThreads];
            int itemsPerThread = this.vector.Length/numberOfThreads;
            for (int i = 0; i < this.numberOfThreads; i++)
            {
                workers[i] = new Worker(this.vector,
                    i*itemsPerThread,
                    (i<this.numberOfThreads-1) ? (i+1)*itemsPerThread-1 : this.vector.Length-1 // last one
                    );
            }

            Thread[] threads = new Thread[workers.Length];
            for (int i = 0; i<workers.Length; i++) {
                threads[i] = new Thread(workers[i].Compute);
                threads[i].Name = "Worker Vector Modulus " + (i+1);
                threads[i].Priority = ThreadPriority.BelowNormal;
                threads[i].Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            long result = 0;
            foreach (Worker worker in workers) {
                result += worker.Result;
            }
            return Math.Sqrt(result);
        }


        //(i<this.numberOfThreads-1) ? (i+1)*itemsPerThread-1 : this.vector.Length-1
        //EQUIVALE:
        //if (i < this.numberOfThreads - 1) {
        //      (i+1)*itemsPerThread - 1;
        //} else {
        //      this.vector.Length - 1;
        //}
    }
}