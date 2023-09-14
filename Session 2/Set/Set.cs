using System;

namespace TPP.Laboratory.ObjectOrientation.Lab02
{
    /// <summary>
    /// Clase Set
    /// </summary>
    public class Set : List
    {
        /// <summary>
        /// Operador +
        /// Añadir elementos
        /// </summary>
        /// <param name="s"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Set operator +(Set s, object element)
        {
            if (element != null)
            {
                if (!s.Contains(element))
                {
                    s.Add(element);
                    return s;
                }
                return s;
            } else
            {
                throw new ArgumentException("El elemento a añadir no puede ser null");
            }            
        }

        /// <summary>
        /// Operador -
        /// Eliminar elementos
        /// </summary>
        /// <param name="s"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Set operator -(Set s, object element)
        {
            if (element != null)
            {
                if (s.Contains(element))
                {
                    s.Remove(element);
                    return s;
                }
                return s;
            }
            else
            {
                throw new ArgumentException("El elemento a borrar no puede ser null");
            }            
        }

        /// <summary>
        /// Operador []
        /// Retornar elementos y asignarlos
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object this[uint index]
        { 
            get
            {
                return GetElement(index);
            }
            //Añadido extra para pruebas
            set
            {
                if (!this.Contains(value) && index < this.NumberOfElements)
                {
                    SetElement(index, value);
                }
            }
            //Añadido extra para pruebas
        }

        /// <summary>
        /// Operador |
        /// Unión de conjuntos
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Set operator |(Set a, Set b)
        {
            if (a != null && b != null)
            {
                Set union = new Set();
                for (uint i = 0; i < a.NumberOfElements; i++)
                {
                    union+=a[i];
                }
                for (uint i = 0; i < b.NumberOfElements; i++)
                {
                    union+=b[i];
                }
                return union;
            } 
            else
            {
                throw new ArgumentException("Los conjuntos no pueden ser null");
            }            
        }

        /// <summary>
        /// Operador &
        /// Intersección de conjuntos
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Set operator &(Set a, Set b)
        {
            if (a != null && b != null)
            {
                Set intersection = new Set();
                for (uint i = 0; i < a.NumberOfElements; i++)
                {
                    if (b.Contains(a[i]))
                    {
                        intersection+=a[i];
                    }
                }
                return intersection;
            } 
            else
            {
                throw new ArgumentException("Los conjuntos no pueden ser null");
            }
        }

        /// <summary>
        /// Operador -
        /// Diferencia de conjuntos
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Set operator -(Set a, Set b)
        {
            if (a != null && b != null)
            {
                Set difference = new Set();
                for (uint i = 0; i < a.NumberOfElements; i++)
                {
                    if (!b.Contains(a[i]))
                    {
                        difference+=a[i];
                    }
                }
                return difference;
            }
            else
            {
                throw new ArgumentException("Los conjuntos no pueden ser null");
            }
        }
        
        /// <summary>
        /// Operador ^
        /// Comprobar la existencia de elementos
        /// </summary>
        /// <param name="s"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool operator ^(Set s, object element)
        {
            if (element != null)
            {
                return s.Contains(element);
            } 
            else
            {
                throw new ArgumentException("El elemento a comprobar no puede ser null");
            }            
        }
    }
}
