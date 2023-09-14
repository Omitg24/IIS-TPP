using System;
using System.Threading;
using System.Text;

namespace TPP.Laboratory.Concurrency.Lab09 {
    /// <summary>
    /// Clase ThreadDemo
    /// </summary>
    class ThreadDemo {
        /// <summary>
        /// Método Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            if (args.Length > 0)
            {
                int numberOfThreads = Convert.ToInt32(args[0]);   //numberOfThreads = 2;
                for (int i = 0; i < numberOfThreads; i++)
                {             
                    new Thread(new MessageThread().Run).Start();    //Multihilo
                }
            }
            new MessageThread().Run();   //Monohilo
        }
    }
}
