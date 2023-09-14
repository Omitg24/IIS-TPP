using System;
using System.Text;
using System.Diagnostics;

namespace TPP.Laboratory.ObjectOrientation.Lab03
{
    /// <summary>
    /// Clase Stack
    /// </summary>
    public class Stack<T>
    {
        /// <summary>
        /// Atributo stack
        /// </summary>
        private List<T> stack;

        /// <summary>
        /// Atributo maxNumberOfElements
        /// </summary>
        private uint maxNumberOfElements;

        /// <summary>
        /// Propiedad IsEmpty
        /// </summary>
        public bool IsEmpty
        {
            get { return stack.NumberOfElements == 0; }
        }

        /// <summary>
        /// Propiedad IsFull
        /// </summary>
        public bool IsFull
        {
            get { return stack.NumberOfElements == this.maxNumberOfElements; }
        }

        /// <summary>
        /// Constructor Stack
        /// </summary>
        /// <param name="maxNumberOfElements"></param>
        public Stack(uint maxNumberOfElements)
        {
            //PRECONDICIONES: El número máximo de elementos no puede ser 0.
            if (maxNumberOfElements == 0)
            {
                throw new ArgumentException("El número máximo de elementos no puede ser 0");
            }
            this.stack = new List<T>();
            this.maxNumberOfElements = maxNumberOfElements;           
            //POSTCONDICIONES: La pila debe de estar vacía.
            Debug.Assert(IsEmpty, "La pila debe de estar vacía");
            //INVARIANTES: La pila no puede estar vacía y llena al mismo tiempo.
            //             No hay ningún elemento null.
            //             El número de elementos no puede superar al número máximo de elementos.
            Invariants();
        }

        /// <summary>
        /// Método Push
        /// Método que añade al inicio de la pila el elemento 
        /// pasado por el parámetro:
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public T Push (T element)
        {
            //INVARIANTES: La pila no puede estar vacía y llena al mismo tiempo.
            //             No hay ningún elemento null.
            //             El número de elementos no puede superar al número máximo de elementos.
            Invariants();
            //PRECONDICIONES: El elemento no puede ser null.
            if (element == null)
            {
                throw new ArgumentException("El elemento no puede ser null");
            }
            stack.AddByIndex(0, element);            
            //POSTCONDICIONES: La pila no puede estar vacía.
            Debug.Assert(!IsEmpty, "La pila no puede estar vacía");
            //INVARIANTES: La pila no puede estar vacía y llena al mismo tiempo.
            //             No hay ningún elemento null.
            //             El número de elementos no puede superar al número máximo de elementos.
            Invariants();
            return element;
        }

        /// <summary>
        /// Método Pop
        /// Método que elimina y devuelve el elemento que se encuentra
        /// al inicio de la pila.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            //PRECONDICIONES: La pila no puede estar vacía
            if (IsEmpty)
            {
                throw new InvalidOperationException("La pila no puede estar vacía");
            }
            T element = stack.GetElement(0);
            stack.Remove(element);
            //POSTCONDICIONES: La pila no puede estar llena
            Debug.Assert(!IsFull, "La pila no puede estar llena");
            //INVARIANTES: La pila no puede estar vacía y llena al mismo tiempo.
            //             No hay ningún elemento null.
            //             El número de elementos no puede superar al número máximo de elementos.
            Invariants();
            return element;                        
        }

        //INVARIANTES:
        /// <summary>
        /// Método Invariants
        /// Método que llama a las invariantes
        /// </summary>
        private void Invariants()
        {
            Debug.Assert(stack.CheckNulls(), "No debe de haber ningún elemento null");
            Debug.Assert(CheckFullEmpty(), "La pila no puede estar vacía y llena al mismo tiempo");
            Debug.Assert(CheckNumberOfElements(), "El número de elementos no puede superar al número máximo de elementos");
        }

        /// <summary>
        /// Método CheckFullEmpty
        /// Método que comprueba que la pila no está vacía 
        /// y llena al mismo tiempo
        /// </summary>
        /// <returns></returns>
        public bool CheckFullEmpty()
        {
            return !(IsFull && IsEmpty);
        }

        /// <summary>
        /// Método que comprueba que el número de elementos
        /// es menor que el número máximo de elementos
        /// </summary>
        /// <returns></returns>
        public bool CheckNumberOfElements()
        {
            return stack.NumberOfElements <= this.maxNumberOfElements;
        }
    }
}