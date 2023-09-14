using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TPP.Laboratory.ObjectOrientation.Lab02 {

    /// <summary>
    /// Clase StringExtension
    /// </summary>
    static class StringExtesion {
        /// <summary>
        /// Método CountWords
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public uint CountWords(this string str)
        {
            // static type of var?
            var lines = Regex.Split(str, "\r|\n|[.]|[,]|[ ]");
            uint numberOfWords = 0;
            foreach (var line in lines)
                if (!String.IsNullOrEmpty(line) && !String.IsNullOrWhiteSpace(line))
                    numberOfWords++;
            return numberOfWords;
        }
    }
}
