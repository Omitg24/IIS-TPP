using System;
using System.Threading;
using System.Text;

namespace TPP.Laboratory.Concurrency.Lab09 {

    /// <summary>
    /// Clase MessageThread
    /// </summary>
    internal class MessageThread {
        /// <summary>
        /// Atributo numberOfThreads
        /// </summary>
        private static uint numberOfThreads = 0;
        /// <summary>
        /// Propiedad ThreadNumber
        /// </summary>
        internal uint ThreadNumber { get; private set; }

        /// <summary>
        /// Constructor MessageThread()(
        /// </summary>
        internal MessageThread() {
            this.ThreadNumber = ++numberOfThreads;
        }

        /// <summary>
        /// Atributo random
        /// </summary>
        private Random random = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// Método MultiplyString
        /// </summary>
        /// <param name="str"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private static string MultiplyString(string str, uint number) {
            StringBuilder sb = new StringBuilder();
            for (uint i = 0; i < number; i++)
                sb.Append(str);
            return sb.ToString();
        }

        /// <summary>
        /// Método Run
        /// </summary>
        internal void Run() {
            while (true) {
                Thread.Sleep(this.random.Next(500, 2000));
                Console.WriteLine("{0}Thread {1}, ThreadID {2}.", 
                    MultiplyString("-", this.ThreadNumber),
                    this.ThreadNumber,
                    Thread.CurrentThread.ManagedThreadId);
            }
        }


    }
}
