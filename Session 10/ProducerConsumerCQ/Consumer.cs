using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPP.Laboratory.Concurrency.Lab10
{
    /// <summary>
    /// Clase Counter
    /// </summary>
    class Consumer
    {
        /// <summary>
        /// Atributo queue
        /// </summary>
        private ConcurrentQueue<Product> queue;

        /// <summary>
        /// Constructor Consumer
        /// </summary>
        /// <param name="queue"></param>
        public Consumer(ConcurrentQueue<Product> queue)
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
                Console.WriteLine("- Dequeuing a product...");
                Product product = null;
                while (queue.IsEmpty)
                {
                    Thread.Sleep(100);
                }
                product = queue.Dequeue();
                Console.WriteLine("- Dequeued {0}.", product);
                Thread.Sleep(random.Next(300, 700));
            }
        }
    }
}
