using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TPP.Laboratory.Concurrency.Lab11 {

    /// <summary>
    /// Clase Processing
    /// </summary>
    public static class Processing {

        /// <summary>
        /// Método ReadTextFile
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static String ReadTextFile(string fileName) {
            using (StreamReader stream = File.OpenText(fileName)) {
                StringBuilder text = new StringBuilder();
                string line;
                while ((line = stream.ReadLine()) != null) {
                    text.AppendLine(line);
                }
                return text.ToString();
            }
        }

        /// <summary>
        /// Método DivideIntoWords
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string[] DivideIntoWords(String text) {
            return text.Split(new char[] { ' ', '\r', '\n', ',', '.', ';', ':', '-', '!', '¡', '¿', '?', '/', '«',
                                            '»', '_', '(', ')', '\"', '*', '\'', 'º', '[', ']', '#' },
                StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Método CountWordsSequential
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static Dictionary<string, int> CountWordsSequential(String[] words)
        {
            var wordsCounter = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (!wordsCounter.ContainsKey(word))
                {
                    wordsCounter[word] = 1;
                }
                else
                {
                    wordsCounter[word]++;
                }
            }
            return wordsCounter;
        }

        /// <summary>
        /// Método CountWordsTPL
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static Dictionary<string, int> CountWordsTPL(String[] words)
        {
            var wordsCounter = new Dictionary<string, int>();
            Parallel.ForEach(words, word =>
            {
                lock (wordsCounter)
                {
                    if (!wordsCounter.ContainsKey(word))
                    {
                        wordsCounter[word] = 1;
                    }
                    else
                    {
                        wordsCounter[word]++;
                    }
                }
            });
            return wordsCounter;
        }

        /// <summary>
        /// Método CountWordsPLinq
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static Dictionary<string, int> CountWordsPLinq(String[] words)
        {
            var wordsCounter = words.AsParallel().Aggregate(new Dictionary<string, int>(), (acum, value) =>
            {
                lock (acum)
                {
                    if (!acum.ContainsKey(value))
                    {
                        acum[value] = 1;
                    }
                    else
                    {
                        acum[value]++;
                    }
                }
                return acum;
            });
            return wordsCounter;
        }
    }
}
