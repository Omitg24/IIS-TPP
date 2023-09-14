using LinkedList;
using System;
using System.Collections.Generic;

namespace Cola
{
    /// <summary>
    /// Clase Cola
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Cola<T> : LinkedList.List<T>
    {
        /// <summary>
        /// Atributo predicates
        /// </summary>
        private readonly IEnumerable<Predicate<T>> predicates;

        /// <summary>
        /// Propiedad EstaVacia
        /// </summary>
        public bool EstaVacía
        {
            get { return this.NumberOfElements == 0; }
        }

        /// <summary>
        /// Constructor Cola
        /// </summary>
        /// <param name="predicates"></param>
        public Cola(IEnumerable<Predicate<T>> predicates)
        {
            this.predicates = predicates;
        }

        /// <summary>
        /// Método Encolar
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Encolar(T element)
        {
            GetEnumerator().Reset();
            foreach (var predicate in predicates)
            {
                if (!predicate(element))
                {
                    return false;
                }
            }
            Add(element);            
            return true;
        }

        /// <summary>
        /// Método Desencolar
        /// </summary>
        public void Desencolar(out T element)
        {
            element = GetElement(0);            
            Remove(element);            
        }
    }
}
