using System;
using System.Threading;

namespace TPP.Laboratory.Concurrency.Lab09 
{
    /// <summary>
    /// Clase Master
    /// </summary>
    public class Master {
        /// <summary>
        /// Atributo data
        /// </summary>
        private BitcoinValueData[] data;

        /// <summary>
        /// Atributo numberOfThreads
        /// </summary>
        private int numberOfThreads;

        /// <summary>
        /// Atributo limit
        /// </summary>
        private int limit;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        /// <param name="numberOfThreads"></param>
        /// <param name="limit"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Master(BitcoinValueData[] data, int numberOfThreads, int limit) {
            //PRECONDICIONES: El array debe ser distinto de null.
            //                El número de hilos debe ser mayor a 0 y menor que la longitud del array.
            if (data == null)
            {
                throw new ArgumentException("El array debe ser distinto de null.");
            }
            else if (numberOfThreads <= 0 || numberOfThreads > data.Length)
            {
                throw new ArgumentException("El número de hilos debe ser mayor a 0 y menor que la longitud del array.");
            }
            this.data = data;            
            this.numberOfThreads = numberOfThreads;
            this.limit = limit;
        }

        /// <summary>
        /// Método ComputeCount
        /// </summary>
        /// <returns></returns>
        public int ComputeCount() {
            Worker[] workers = new Worker[this.numberOfThreads];
            int itemsPerThread = this.data.Length/numberOfThreads;
            for(int i=0; i < this.numberOfThreads; i++) { 
                workers[i] = new Worker(this.data,
                                        i * itemsPerThread, 
                                        (i<this.numberOfThreads-1) ? (i+1)*itemsPerThread-1: this.data.Length-1
                                        , limit);
            }

            Thread[] threads = new Thread[workers.Length];
            for(int i=0;i<workers.Length;i++) {
                threads[i] = new Thread(workers[i].Compute); 
                threads[i].Name = "Worker Vector Modulus " + (i+1); 
                threads[i].Priority = ThreadPriority.BelowNormal; 
                threads[i].Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            int count = 0;
            foreach (Worker worker in workers) {
                count += worker.Result;
            }
            return count;
        }
    }
}
