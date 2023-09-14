using System;

namespace TPP.Laboratory.Concurrency.Lab09
{
    /// <summary>
    /// Clase Program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Método Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            BitcoinValueData[] data = Utils.GetBitcoinData();

            Console.Write("Introduce the limit: ");
            int limit = Convert.ToInt32(Console.In.ReadLine());

            Master master = new Master(data, 1, limit);
            DateTime before = DateTime.Now;
            int result = master.ComputeCount();
            DateTime after = DateTime.Now;
            Console.WriteLine($"Result with one thread: {result}.");
            Console.WriteLine($"Elapsed time: {(after - before).Ticks} ticks.");

            master = new Master(data, 4, limit);
            before = DateTime.Now;
            result = master.ComputeCount();
            after = DateTime.Now;
            Console.WriteLine($"Result with four threads: {result}.");
            Console.WriteLine($"Elapsed time: {(after - before).Ticks} ticks.");
        }
    }
}
