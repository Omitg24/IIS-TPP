using System;
using System.Collections.Generic;
using System.Linq;

namespace TPP.Laboratory.Functional.Lab06 {

    /// <summary>
    /// Clase Program
    /// </summary>
    static class Program {

        /// <summary>
        /// Método Addition
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int Addition(int a, int b) {
            return a + b;
        }

        /// <summary>
        /// Método CurryedAdd
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static Func<int, int> CurryedAdd(int a)
        {
            return b => b + a;
        }

        /// <summary>
        /// Método GreaterThan
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static Predicate<int> GreaterThan(int a)
        {
            return b => b > a;
        }

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
        /// Método que muestra la colección
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        public static void Show1<T>(this IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Método Show
        /// Método que muestra la colección y la devuelve
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static IEnumerable<T> Show2<T>(this IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            return collection;
        }

        /// <summary>
        /// Método Filter
        /// Método que devuelve una lista con los elementos que cumplan la condición de la colección
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            IList<T> filteredCollection = new List<T>();
            foreach (T item in collection)
            {
                if (condition(item))
                {
                    filteredCollection.Add(item);
                }
            }
            return filteredCollection;
        }

        /// <summary>
        /// Método Main
        /// </summary>
        static void Main() {            
            //Currying
            Console.WriteLine($"Addition without currying: {Addition(1, 2)}");
            Console.WriteLine($"Addition with currying: {CurryedAdd(1)(2)}");

            //Currying with Map and Show
            Console.WriteLine("\nCurrying with collections");
            var increment = CurryedAdd(1);
            int[] values = new int[] { -3, -2, -1, 0, 1, 2, 3 };
            Console.Write("-- Addition: ");
            values.Map(val => Addition(1, val)).Show1();
            Console.Write("-- CurryedAdd: ");
            values.Map(CurryedAdd(1)).Show1();
            Console.Write("-- Increment: ");
            values.Map(increment).Show1();

            //Tests with Show2
            Console.WriteLine("\nTests with Show2");
            var random = new Random();
            var numbers = new int[10];
            numbers.Map(x => random.Next(-100, 100)).Show2();
            numbers.Map(x => random.Next(-100, 100)).Show2().Filter(GreaterThan(5)).Show2();
        }
    }
}
