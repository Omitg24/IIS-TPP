using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace TPP.Laboratory.Concurrency.Lab11 {

    /// <summary>
    /// Clase Program
    /// </summary>
    class Program {

        /// <summary>
        /// Método Main
        /// </summary>
        static void Main() {
            Stopwatch chrono = new Stopwatch();
            chrono.Start();
            string[] files = Directory.GetFiles(@"..\..\..\..\pics", "*.jpg");
            string newDirectory = @"..\..\..\..\pics\rotated";
            Directory.CreateDirectory(newDirectory);
            foreach (string file in files) {
                string fileName = Path.GetFileName(file);
                using (Bitmap bitmap = new Bitmap(file)) {
                    Console.WriteLine("Processing the file \"{0}\".", fileName);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(newDirectory, fileName));
                }
            }
            chrono.Stop();
            long sequentialTime = chrono.ElapsedMilliseconds;
            Console.WriteLine("Elapsed time: {0:N} milliseconds.", sequentialTime);
            Console.WriteLine("-----------------------------------------");

            chrono.Restart();
            var threads = new HashSet<int>();
            Parallel.ForEach(files, file =>
            {
                lock (threads)
                {
                    threads.Add(Thread.CurrentThread.ManagedThreadId);
                }
                string fileName = Path.GetFileName(file);
                using (Bitmap bitmap = new Bitmap(file))
                {
                    Console.WriteLine("Processing the file \"{0}\".", fileName);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(newDirectory, fileName));
                }
            });
            chrono.Stop();
            long parallelTime = chrono.ElapsedMilliseconds;
            Console.WriteLine("Elapsed time: {0:N} milliseconds.", parallelTime);
            Console.WriteLine($"--Using {threads.Count()} threads");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Parallel is {sequentialTime/parallelTime*100}% faster than Sequential");
        }
    }
}
