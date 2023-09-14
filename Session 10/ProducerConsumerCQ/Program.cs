using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            ConcurrentQueue<Product> queue = new ConcurrentQueue<Product>();
            Producer producer = new Producer(queue);
            Consumer consumer = new Consumer(queue);
            new Thread(producer.Run).Start();
            Thread.Sleep(2000);
            new Thread(consumer.Run).Start();
        }
    }
}
