using System;
using System.Collections.Generic;
using System.Linq;

namespace TPP.Laboratory.Functional.Lab07
{
    /// <summary>
    /// Clase Functions
    /// </summary>
    public static class Functions
    {
        /// <summary>
        /// Método Map
        /// Método que devuelve la lista tras aplicarle la función
        /// </summary>
        /// <typeparam name="TE"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="collection"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static IEnumerable<TS> Map<TE, TS>(this IEnumerable<TE> collection, Func<TE, TS> f)
        {
            IList<TS> result = new List<TS>();
            foreach(TE item in collection)
            {
                result.Add(f(item));
            }
            return result;
        }

        /// <summary>
        /// Método Find
        /// Método que devuelve el primer elemento que cumpla la condición de la colección
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static T Find<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            foreach (T item in collection)
            {
                if (condition(item))
                {
                    return item;
                }
            }
            return default;
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
        /// Método Reduce
        /// Método que devuelve lo que se haya pedido de la colección
        /// </summary>
        /// <typeparam name="TE"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="collection"></param>
        /// <param name="f"></param>
        /// <param name="optionalParameter"></param>
        /// <returns></returns>
        public static TS Reduce<TE, TS>(this IEnumerable<TE> collection, Func<TS, TE, TS> f, TS optional = default)
        {
            TS result = optional;
            foreach (TE item in collection)
            {
                result = f(result, item);
            }
            return result;
        }

        /// <summary>
        /// Método ToArray
        /// Método que pasa una colección a un Array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static T[] ToArray<T>(this IEnumerable<T> collection)
        {
            T[] result = new T[collection.Count()];
            int counter = 0;
            foreach (T item in collection) {
                result[counter]=item;
                counter++;
            }
            return result;
        }       
    }
}
