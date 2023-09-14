using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Linq;
using System.Collections.Generic;

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
        /// Método PunctuationMars
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int PunctuationMarks(string text) {
            return text.Count(character => character == '.' || character == ',' || character == ';' || character == ':'); 
        }

        /// <summary>
        /// Método LongestWords
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static string[] LongestWords(string[] words) {
            // We use Linq higher-order functions
            return words
                .GroupBy(word => word.Length)  // words are classified in groups of words with the same length
                .OrderByDescending(group => group.Key)  // the groups are ordered by descending length
                .Select(group => group.Distinct()) // repeated words per group are erased
                .First() // we take the first group (words with the greatest length)
                .ToArray(); // and convert it to an array
        }

        /// <summary>
        /// Método ShortestWords
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static string[] ShortestWords(string[] words) {
            return words
                .GroupBy(word => word.Length) // words are classified in groups of words with the same length
                .OrderBy(grupo => grupo.Key) // the groups are ordered by ascending length
                .Select(grupo => grupo.Distinct()) // repeated words per group are erased
                .First() // we take the first group (words with the smallest length)
                .ToArray(); // and convert it to an array

        }

        /// <summary>
        /// Método WordsAppearFewerTimes
        /// </summary>
        /// <param name="words"></param>
        /// <param name="occurrence"></param>
        /// <returns></returns>
        public static string[] WordsAppearFewerTimes(string[] words, out int occurrence) {
            var wordsAndOccurrences = words
                .GroupBy(word => word.ToLower()) // words are grouped by its lowercase representation
                .Select(group => new { Word = group.Key, Occurrences = group.Count() }) // we convert it in a list of pairs {Word, Occurrence}
                .OrderBy(pair => pair.Occurrences); // pairs are sorted ascending by occurrences
            // We take lowest occurrence from the first pair 
            int lowestOccurrence = occurrence = wordsAndOccurrences.First().Occurrences;
            // We return all the words whose occurrences are the same to the lowest one
            return wordsAndOccurrences
                .Where(pair => pair.Occurrences == lowestOccurrence) // pairs are filtered with the lowest number of occurrences
                .Select(pair => pair.Word)  // we take the lowercase word
                .ToArray(); // and convert it to an array
        }

        /// <summary>
        /// Método WordsAppearMoreTimes
        /// </summary>
        /// <param name="words"></param>
        /// <param name="occurrence"></param>
        /// <returns></returns>
        public static string[] WordsAppearMoreTimes(string[] words, out int occurrence) {
            var wordsAndOccurrences = words
                .GroupBy(word => word.ToLower()) // words are grouped by its lowercase representation
                .Select(group => new { Word = group.Key, Occurrences = group.Count() }) // we convert it in a list of pairs {Word, Occurrence}
                .OrderByDescending(pair => pair.Occurrences); // pairs are sorted descending by occurrences
            // We take greatest occurrence from the first pair 
            int greatestOccurrence = occurrence = wordsAndOccurrences.First().Occurrences;
            // We return all the words whose occurrences are the same to the greatest one
            return wordsAndOccurrences
                .Where(pair => pair.Occurrences == greatestOccurrence) // pairs are filtered with the greatest number of occurrences
                .Select(pair => pair.Word)  // we take the lowercase word
                .ToArray(); // and convert it to an array
        }
    }
}
