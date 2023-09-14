using System.Linq;
using System.Collections.Generic;
using System;

namespace TPP.Laboratory.Functional.Lab07
{
    /// <summary>
    /// Clase Functions
    /// </summary>
    static public class Functions
    {
        /// <summary>
        /// Método Map
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="collection"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> Map1<TElement, TResult>(this IEnumerable<TElement> collection, Func<TElement, TResult> function)
        {
            
            //List<TResult> list = new List<TResult>();
            //foreach (TElement element in collection)
            //{
            //    list.Add(function(element));
            //}
            //return list;
            foreach (TElement item in collection)
            {
                yield return function(item);
            }
        }

        /// <summary>
        /// Método Map
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="collection"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> Map2<TElement, TResult>(this IEnumerable<TElement> collection, Func<TElement, TResult> function)
        {

            List<TResult> list = new List<TResult>();
            foreach (TElement element in collection)
            {
                list.Add(function(element));
            }
            return list;
        }

        /// <summary>
        /// Método ForEach
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="function"></param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> function)
        {
            foreach(T element in collection)
            {
                function(element);
            }                
        }
    }
}
