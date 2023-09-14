using System;
using System.IO;

namespace TPP.Laboratory.Concurrency.Lab09
{
    /// <summary>
    /// Clase Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Constante CSV_SEPARATOR
        /// </summary>
        private const string CSV_SEPARATOR = ";";

        /// <summary>
        /// Método Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            BitcoinValueData[] data = Utils.GetBitcoinData();
            int maxNumberOfThreads = 50;
            int limit = 7000;

            ShowLine(Console.Out,"Number of Thread", "Ticks", "Count");
            for (int i = 1; i <= maxNumberOfThreads; i++)
            {
                Master master = new Master(data, i, limit);
                DateTime before = DateTime.Now;
                int count = master.ComputeCount();
                DateTime after = DateTime.Now;
                ShowLine(Console.Out, i, (after - before).Ticks, count);
                GC.Collect();
                GC.WaitForFullGCComplete();
            }
        }

        /// <summary>
        /// Método ShowLine
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="numberOfThreadsTittle"></param>
        /// <param name="ticksTitle"></param>
        /// <param name="countTitle"></param>
        public static void ShowLine(TextWriter stream, string numberOfThreadsTittle, string ticksTitle, string countTitle)
        {
            stream.WriteLine($"{numberOfThreadsTittle}{CSV_SEPARATOR}{ticksTitle}{CSV_SEPARATOR}{countTitle}");
        }

        /// <summary>
        /// Método ShowLine
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="numberOfThreads"></param>
        /// <param name="ticks"></param>
        /// <param name="count"></param>
        public static void ShowLine(TextWriter stream, int numberOfThreads, long ticks, int count)
        {
            stream.WriteLine($"{numberOfThreads}{CSV_SEPARATOR}{ticks}{CSV_SEPARATOR}{count}");
        }
    }
}
