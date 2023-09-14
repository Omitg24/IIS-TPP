using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPP.Laboratory.Concurrency.Lab10
{
    /// <summary>
    /// Clase Producer
    /// </summary>
    class Producer
    {
        /// <summary>
        /// Atributo queue
        /// </summary>
        private Queue<Product> queue;

        /// <summary>
        /// Atributo numberOfProductsProduced
        /// </summary>
        private int numberOfProductsProduced;

        /// <summary>
        /// Método Run
        /// </summary>
        public void Run()
        {
            Random random = new Random();
            while (true)
            {
                Product product = new Product(++numberOfProductsProduced);
                Console.WriteLine("+ Enqueuing {0}...", product);
                lock (queue) { 
                    queue.Enqueue(product);
                }
                Console.WriteLine("+ {0} enqueued.", product);
                Thread.Sleep(random.Next(500, 1000));
            }
        }

        /// <summary>
        /// Constructor Producer
        /// </summary>
        /// <param name="queue"></param>
        public Producer(Queue<Product> queue)
        {
            this.queue = queue;
        }
    }
}
