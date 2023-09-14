using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TPP.Laboratory.Concurrency.Lab11 {

    /// <summary>
    /// Clase Program
    /// </summary>
    class Program {

        /// <summary>
        /// Método Main
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args) {
            String text = Processing.ReadTextFile(@"..\..\..\clarin.txt");
            string[] words = Processing.DivideIntoWords(text);

            Stopwatch crono = new Stopwatch();
            crono.Start();
            int punctuationMarks = Processing.PunctuationMarks(text);
            var longestWords = Processing.LongestWords(words);
            var shortestWords = Processing.ShortestWords(words);
            int greatestOccurrence, lowestOccurrence;
            var wordsAppearMoreTimes = Processing.WordsAppearMoreTimes(words, out greatestOccurrence);
            var wordsAppearFewerTimes = Processing.WordsAppearFewerTimes(words, out lowestOccurrence);
            crono.Stop();

            ShowResults(punctuationMarks, shortestWords, longestWords, wordsAppearFewerTimes, lowestOccurrence,
                wordsAppearMoreTimes, greatestOccurrence);

            long sequentialTime = crono.ElapsedMilliseconds;
            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", sequentialTime);
            Console.WriteLine("-----------------------------------------");

            crono.Restart();
            Parallel.Invoke(
                () => punctuationMarks = Processing.PunctuationMarks(text),
                () => longestWords = Processing.LongestWords(words),
                () => shortestWords = Processing.ShortestWords(words),
                () => wordsAppearMoreTimes = Processing.WordsAppearMoreTimes(words, out greatestOccurrence),
                () => wordsAppearFewerTimes = Processing.WordsAppearFewerTimes(words, out lowestOccurrence)
                );
            crono.Stop();

            ShowResults(punctuationMarks, shortestWords, longestWords, wordsAppearFewerTimes, lowestOccurrence,
                wordsAppearMoreTimes, greatestOccurrence);

            long parallelTime = crono.ElapsedMilliseconds;
            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", parallelTime);
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Parallel is {sequentialTime/parallelTime*100}% faster than Sequential");
        }

        /// <summary>
        /// Método ShowResults
        /// </summary>
        /// <param name="punctuationMarks"></param>
        /// <param name="shortestWords"></param>
        /// <param name="longestWords"></param>
        /// <param name="wordsAppearFewerTimes"></param>
        /// <param name="lowestOccurrence"></param>
        /// <param name="wordsAppearMoreTimes"></param>
        /// <param name="greatestOccurrence"></param>
        public static void ShowResults(int punctuationMarks, string[] shortestWords, string[] longestWords,
                                       string[] wordsAppearFewerTimes, int lowestOccurrence,
                                       string[] wordsAppearMoreTimes, int greatestOccurrence) {
            const int maxNumberOfElementsToShow = 20;

            Console.WriteLine("> There were {0} punctuation marks. ", punctuationMarks);

            Console.Write("> {0} shortest words: ", shortestWords.Count());
            Show(shortestWords, Console.Out, maxNumberOfElementsToShow);
            Console.WriteLine();

            Console.Write("> {0} longest words: ", longestWords.Count());
            Show(longestWords, Console.Out, maxNumberOfElementsToShow);
            Console.WriteLine();

            Console.Write("> {0} words appeared fewer times ({1}): ", wordsAppearFewerTimes.Count(), lowestOccurrence);
            Show(wordsAppearFewerTimes, Console.Out, maxNumberOfElementsToShow);
            Console.WriteLine();

            Console.Write("> {0} words appreared more times ({1}): ", wordsAppearMoreTimes.Count(), greatestOccurrence);
            Show(wordsAppearMoreTimes, Console.Out, maxNumberOfElementsToShow);
            Console.WriteLine();
        }

        /// <summary>
        /// Método Show
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="stream"></param>
        /// <param name="maxNumberOfElements"></param>
        private static void Show<T>(IEnumerable<T> collection, TextWriter stream, int maxNumberOfElements) {
            int i = 0;
            foreach (T element in collection) {
                stream.Write(element);
                i = i + 1;
                if (i == maxNumberOfElements) {
                    stream.Write("...");
                    break;
                }
                if (i < collection.Count())
                    stream.Write(", ");
            }
        }
    }
}
