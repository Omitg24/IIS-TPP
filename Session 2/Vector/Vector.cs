using System;

namespace TPP.Laboratory.ObjectOrientation.Lab02
{
    /// <summary>
    /// Clase Vector
    /// Clase Vector
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// Atributo vector
        /// </summary>
        private int[] vector;

        /// <summary>
        /// Propiedad Size
        /// </summary>
        public int Size { get { return vector.Length; } }

        /// <summary>
        /// Constructor Vector
        /// </summary>
        public Vector()
        {
            this.vector = new int[0];
        }

        /// <summary>
        /// Método Add
        /// Método que añade elementos al vector
        /// </summary>
        /// <param name="element"></param>
        public void Add(int element)
        {
            Array.Resize(ref vector, Size + 1);
            vector[Size - 1] = element;
        }

        /// <summary>
        /// Método GetElement
        /// Método que devuelve el elemento de la posición pasada
        /// por el parámetro:
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object GetElement(uint index)
        {
            if (Size == 0)
            {
                throw new ArgumentException("El vector no puede estar vacío");
            } else if (index >= Size)
            {
                throw new ArgumentException("El indice no puede ser superior al tamaño del vector");
            }
            {
                return vector[index];
            }            
        }

        /// <summary>
        /// Método SetElement
        /// Método que setea el elemento que se encuentra en la posición
        /// pasada por parámetro al elemento pasado por parámetro
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        public void SetElement(uint index, int element)
        {
            if (index >= Size)
            {
                throw new ArgumentException("El indice no puede ser superior al tamaño del vector");
            } else
            {
                vector[index] = element;
            }            
        }
    }
}
