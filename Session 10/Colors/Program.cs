using System;
using System.Threading;

namespace TPP.Laboratory.Concurrency.Lab10
{
    /// <summary>
    /// Clase Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Atributo colors
        /// </summary>
        public static readonly ConsoleColor[] colors = {
                    ConsoleColor.DarkBlue,  ConsoleColor.DarkGreen,  ConsoleColor.DarkCyan,
                    ConsoleColor.DarkRed, ConsoleColor.DarkMagenta,  ConsoleColor.DarkYellow,
                    ConsoleColor.DarkGray,  ConsoleColor.Blue,  ConsoleColor.Green,
                    ConsoleColor.Cyan,  ConsoleColor.Red, ConsoleColor.Gray,
                    ConsoleColor.Magenta,  ConsoleColor.Yellow, ConsoleColor.White,
                    ConsoleColor.DarkBlue,  ConsoleColor.DarkGreen,  ConsoleColor.DarkCyan,
                    ConsoleColor.DarkRed, ConsoleColor.DarkMagenta,  ConsoleColor.DarkYellow,
                    ConsoleColor.DarkGray,  ConsoleColor.Blue,  ConsoleColor.Green,
                    ConsoleColor.Cyan,  ConsoleColor.Red, ConsoleColor.Gray,
                    ConsoleColor.Magenta,  ConsoleColor.Yellow, ConsoleColor.White,
                    };

        /// <summary>
        /// Método Main
        /// </summary>
        static void Main()
        {
            Thread[] threads = new Thread[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                Color color = new Color(colors[i]);
                threads[i] = new Thread(color.Show);
            }
            foreach (Thread thread in threads)
                thread.Start();
        }

    }
}
