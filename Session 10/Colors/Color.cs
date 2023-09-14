using System;

namespace TPP.Laboratory.Concurrency.Lab10
{
    /// <summary>
    /// Clase Color
    /// </summary>
    public class Color
    {
        /// <summary>
        /// Atributo color
        /// </summary>
        private ConsoleColor color;

        /// <summary>
        /// Constructor Color
        /// </summary>
        /// <param name="color"></param>
        public Color(ConsoleColor color)
        {
            this.color = color;
        }

        /// <summary>
        /// Método Show
        /// </summary>
        virtual public void Show()
        {
            lock (Console.Out)
            {
                ConsoleColor previousColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.Write("{0}\t", color);
                Console.ForegroundColor = previousColor;
            }            
        }

    }
}
