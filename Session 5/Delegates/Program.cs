using System;
using System.Collections.Generic;
using System.Linq;

namespace TPP.Laboratory.Functional.Lab05
{
    /// <summary>
    /// Clase Program
    /// </summary>
    public static class Program
    {
        
        /// <summary>
        /// Método Map
        /// Método que transforma la lista de un tipo determinado en otro tipo.
        /// </summary>
        /// <typeparam name="TE"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="collection"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static IEnumerable<TS> Map<TE, TS>(this IEnumerable<TE> collection, Func<TE, TS> f)
        {
            //-- Implementación con una Lista
            //IList<TS> result = new List<TS>();
            //foreach(TE item in collection)
            //{
            //    result.Add(f(item));
            //}

            //-- Implementación con un array
            TS[] result = new TS[collection.Count()];
            int counter = 0;
            foreach (TE item in collection)
            {
                result[counter]=f(item);
                counter++;
            }
            return result;
        }

        /// <summary>
        /// Método Show
        /// Método que muestra por pantalla la colección
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="str"></param>
        public static void Show<T> (this IEnumerable<T> collection, string str = null)
        {
            if (str != null)
            {
                Console.WriteLine(str);
            }
            foreach(T item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Método Show
        /// Método que muestra por pantalla la colección
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        public static void Show<T>(this IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Método Square
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        static double Square (double d)
        {
            return d+d;
        }

        /// <summary>
        /// Método ToLower
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string ToLower (string s)
        {
            return s.ToLower() + "!";
        }

        /// <summary>
        /// Método Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //MAP CON DOUBLE
            double[] valuesD = new double[] { -3, -2, -1, 0, 1, 2, 3 };
            Func<double, double> f1 = delegate (double d) { return d+d; };                        
            valuesD.Map(Square).Show("CON FUNCIÓN SQUARE"); //valuesD.Map(x => Square(x))
            valuesD.Map(f1).Show("CON DELEGADO ANÓNIMO"); //valuesD.Map(x => f1(x))
            valuesD.Map(x => x+x).Show("CON EXPRESIÓN LAMBDA");

            Console.WriteLine();

            //MAP CON STRING
            string[] valuesS = new string[] { "hOlA", "mUnDo" };
            Func<string, string> f2 = delegate (string s) { return s.ToLower() + "!"; };
            valuesS.Map(ToLower).Show("CON FUNCIÓN TOLOWER"); //valuesD.Map(x => ToLower(x))
            valuesS.Map(f2).Show("CON DELEGADO ANÓNIMO"); //valuesD.Map(x => f2(x))
            valuesS.Map(x => x.ToLower() + "!").Show("CON EXPRESIÓN LAMBDA");            
        }
    }
}
