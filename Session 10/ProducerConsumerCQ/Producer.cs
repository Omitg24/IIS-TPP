using System;
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
        private ConcurrentQueue<Product> queue;

        /// <summary>
        /// Atributo numberOfProductsProduced
        /// </summary>
        private int numberOfProductsProduced;

        /// <summary>
        /// Constructor Producer
        /// </summary>
        /// <param name="queue"></param>
        public Producer(ConcurrentQueue<Product> queue)
        {
            this.queue = queue;
        }

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
                queue.Enqueue(product);
                Console.WriteLine("+ {0} enqueued.", product);
                Thread.Sleep(random.Next(500, 1000));
            }
        }
    }
}
