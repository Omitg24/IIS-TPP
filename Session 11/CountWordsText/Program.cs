using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TPP.Laboratory.Concurrency.Lab11
{
    /// <summary>
    /// Clase Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Constante N_TIMES
        /// </summary>
        private const int N_TIMES = 30;

        /// <summary>
        /// Método Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            String text = Processing.ReadTextFile(@"..\..\..\clarin.txt");
            string[] words = Processing.DivideIntoWords(text);
            Stopwatch crono = new Stopwatch();
            var wordsCount = new Dictionary<string, int>();

            crono.Start();
            for (int i = 0; i < N_TIMES; i++)
            {
                wordsCount =  Processing.CountWordsSequential(words);
            }
            crono.Stop();

            long sequentialTime = crono.ElapsedMilliseconds;
            Console.WriteLine("SEQUENTIAL:\nElapsed time: {0:N} milliseconds.", sequentialTime/N_TIMES);
            Console.WriteLine("-----------------------------------------");

            crono.Restart();
            for (int i = 0; i < N_TIMES; i++)
            {
                wordsCount =  Processing.CountWordsTPL(words);
            }
            crono.Stop();

            long tplTime = crono.ElapsedMilliseconds;
            Console.WriteLine("TPL:\nElapsed time: {0:N} milliseconds.", tplTime/N_TIMES);
            Console.WriteLine("-----------------------------------------");

            crono.Restart();
            for (int i = 0; i < N_TIMES; i++)
            {
                wordsCount =  Processing.CountWordsPLinq(words);
            }
            crono.Stop();

            long plinqTime = crono.ElapsedMilliseconds;
            Console.WriteLine("PLINQ:\nElapsed time: {0:N} milliseconds.", plinqTime/N_TIMES);
            Console.WriteLine("-----------------------------------------");
        }

        /// <summary>
        /// Método Show
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="stream"></param>
        /// <param name="maxNumberOfElements"></param>
        private static void Show<T>(IEnumerable<T> collection, TextWriter stream, int maxNumberOfElements)
        {
            int i = 0;
            foreach (T element in collection)
            {
                stream.Write(element);
                i = i + 1;
                if (i == maxNumberOfElements)
                {
                    stream.Write("...");
                    break;
                }
                if (i < collection.Count())
                    stream.Write(", ");
            }
        }
    }
}