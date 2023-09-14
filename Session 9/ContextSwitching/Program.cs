using System;
using System.IO;
using System.Runtime.InteropServices;

namespace TPP.Laboratory.Concurrency.Lab09 
{
    /// <summary>
    /// Clase Program
    /// </summary>
    class Program {
        /// <summary>
        /// Import Kernel32.dll
        /// Método QueryPerformanceCounter
        /// </summary>            
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        /// <summary>
        /// Método Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            const int maxNumberOfThreads = 50;
            short[] vector = VectorModulusProgram.CreateRandomVector(100000, -10, 10);
            ShowLine(Console.Out, "Number of threads", "Ticks", "Result");
            for (int numberOfThreads = 1; numberOfThreads <= maxNumberOfThreads; numberOfThreads++) {
                Master master = new Master(vector, numberOfThreads);
                long before = 0;
                QueryPerformanceCounter(out before);
                double result = master.ComputeModulus();
                long after = 0;
                QueryPerformanceCounter(out after);
                ShowLine(Console.Out, numberOfThreads, (after - before), result);
                GC.Collect(); // Garbage collection
                GC.WaitForFullGCComplete();
            }
        }

        /// <summary>
        /// Constante CSV_SEPARATOR
        /// </summary>
        private const string CSV_SEPARATOR = ";";

        /// <summary>
        /// Método ShowLine
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="numberOfThreadsTitle"></param>
        /// <param name="ticksTitle"></param>
        /// <param name="resultTitle"></param>
        static void ShowLine(TextWriter stream, string numberOfThreadsTitle, string ticksTitle, string resultTitle) {
            stream.WriteLine("{0}{3}{1}{3}{2}{3}", numberOfThreadsTitle, ticksTitle, resultTitle, CSV_SEPARATOR);
        }

        /// <summary>
        /// Método ShowLine
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="numberOfThreads"></param>
        /// <param name="ticks"></param>
        /// <param name="result"></param>
        static void ShowLine(TextWriter stream, int numberOfThreads, long ticks, double result) {
            stream.WriteLine("{0}{3}{1:N0}{3}{2:N2}{3}", numberOfThreads, ticks, result, CSV_SEPARATOR);
        }
    }

}
