using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TPP.Laboratory.Concurrency.Lab09
{
    /// <summary>
    /// Clase Utils
    /// </summary>
    public class Utils
    {
        public static bool Verbose = false;

        /// <summary>
        /// Converts a timestamp to a proper date and time
        /// </summary>
        /// <param name="unixTimeStamp">Timestamp in Unix format</param>
        /// <returns>Equivalent DateTime object</returns>
        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        /// <summary>
        /// From the context of a file with Bitcoin values data, build the corresponding objects holding these values
        /// </summary>
        /// <param name="contents">File contents</param>
        /// <returns>Enumerable of BitcoinValueData with the parsed contents</returns>
        private static IEnumerable<BitcoinValueData> GetFileContents(string contents)
        {
            var lines = contents.Split('\n');
            foreach (var line in lines)
            {
                //Clear data and ignore blank lines.
                var lineTemp = line.Trim();
                if (lineTemp.Length == 0) continue;
                var parts = lineTemp.Split(',');
                yield return new BitcoinValueData
                {
                    Timestamp = UnixTimeStampToDateTime(Double.Parse(parts[0])),
                    Value = Double.Parse(parts[1].Replace('.', ','))
                };
            }
        }
        /// <summary>
        /// Read all the data files tied to this program, placed in the /data directory of the C# project.
        /// </summary>
        /// <returns>Enumerable with the data of all files placed in BitcoinValueData objects </returns>
        private static IEnumerable<BitcoinValueData> ReadDataFiles()
        {
            List<BitcoinValueData> listToReturn = new List<BitcoinValueData>();

            foreach (string file in Directory.EnumerateFiles("../../data", "*.txt"))
            {
                if (Verbose)
                    Console.WriteLine("Reading file '" + file + "' ...");
                listToReturn.AddRange(GetFileContents(File.ReadAllText(file)));
            }

            return listToReturn;
        }

        /// <summary>
        /// Read all the data files tied to this program, placed in the /data directory of the C# project.
        /// </summary>
        /// <returns>Array with the data of all files placed in BitcoinValueData objects </returns>
        public static BitcoinValueData[] GetBitcoinData()
        {
            return ReadDataFiles().ToArray();
        }
    }
}
