using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;

namespace LinkedList
{
    /// <summary>
    /// Clase Lists
    /// </summary>
    public class List<T> : IEnumerable<T>
    {
        /// <summary>
        /// Propiedad Head
        /// Nodo cabeza (inicial) de la lista
        /// </summary>
        private Node Head { get; set; }

        /// <summary>
        /// Propiedad NumberOfElements
        /// Número de elementos de la lista
        /// </summary>
        public uint NumberOfElements { get; private set; }

        /// <summary>
        /// Atributo listIterator
        /// </summary>
        private ListIterator listIterator;

        /// <summary>
        /// Constructor List
        /// Constructor sin parámetros de la lista
        /// </summary>
        public List()
        {
            this.NumberOfElements = 0;
            this.listIterator = new ListIterator(null);
            //INVARIANTES: El número de elementos en la lista debe ser el mismo al tamaño de esta.
            Invariants();
        }

        /// <summary>
        /// Constructor List
        /// Constructor al que se le pasa una lista
        /// </summary>
        /// <param name="newList"></param>
        public List(List<T> newList)
        {   
            //PRECONDICIONES: La lista no puede ser null.
            if (newList == null)
            {
                throw new ArgumentException("La lista no puede ser null");
            }
            foreach(T item in newList)
            {
                this.Add(item);
            }
            listIterator.Reset();
            //INVARIANTES: El número de elementos en la lista debe ser el mismo al tamaño de esta.
            Invariants();
        }

        /// <summary>
        /// Método Add
        /// Método que añade a la lista el elemento pasado por
        /// el parámetro:
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element)
        {
            //INVARIANTES: El número de elementos en la lista debe ser el mismo al tamaño de esta.
            Invariants();
            uint previousSize = this.NumberOfElements;
            if (IsEmpty())
            {
                AddFirst(element);
            }
            else
            {
                Node last = GetNode(NumberOfElements - 1);
                last.Next = new Node(element, null);
            }
            this.NumberOfElements++;
            //INVARIANTES: El número de elementos en la lista debe ser el mismo al tamaño de esta.
            Invariants();
            //POSTCONDICIONES: El elemento está en la última posición.
            //                 Se ha incrementado el número de elementos en 1.
            Debug.Assert(GetElement(NumberOfElements - 1).Equals(element), "El elemento debe estar en la última posición");
            Debug.Assert(previousSize < this.NumberOfElements, "El número de elementos debe de incrementarse.");            
        }

        /// <summary>
        /// Método AddFirst
        /// Método que añade el elemento pasado por parámetro 
        /// cuando la lista está vacía
        /// </summary>
        /// <param name="element"></param>
        private void AddFirst(T element)
        {
            this.Head = new Node(element, Head);
            listIterator = new ListIterator(this.Head);
        }

        /// <summary>
        /// Método AddByIndex
        /// Método que añade el elemento pasado por parámetro
        /// en la posición pasada por parámetro
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        public void AddByIndex(uint index, T element)
        {                        
            //PRECONDICIONES: El índice no puede ser mayor al número de elementos.
            if (index > NumberOfElements && index != 0)
            {
                throw new ArgumentException("El indice no puede ser mayor al número de elementos");
            }            
            //INVARIANTES: El número de elementos en la lista debe ser el mismo al tamaño de esta.
            Invariants();
            uint previousSize = this.NumberOfElements;
            if (index == 0)
            {
                AddFirst(element);
            }
            else
            {
                Node previous = GetNode(index - 1);
                previous.Next = new Node(element, previous.Next);
            }
            this.NumberOfElements++;
            //INVARIANTES: El número de elementos en la lista debe ser el mismo al tamaño de esta.
            Invariants();
            //POSTCONDICIONES: El elemento se ha añadido en la posición correspondiente.
            //                 Se ha incrementado el número de elementos en 1.
            Debug.Assert(GetElement(index).Equals(element), "El elemento debe estar en la posición correspondiente");
            Debug.Assert(previousSize < this.NumberOfElements, "El número de elementos debe de incrementarse.");
        }

        /// <summary>
        /// Método Remove
        /// Método que elimina de la lista el elemento
        /// pasado por el parámetro:
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Remove(T element)
        {
            //PRECONDICIONES: La lista no puede estar vacía.
            if (IsEmpty())
            {
                throw new InvalidOperationException("La lista no puede estar vacía");                
            }
            //INVARIANTES: El número de elementos en la lista debe ser el mismo al tamaño de esta.
            Invariants();
            uint previousSize = this.NumberOfElements;
            int elementIndex = IndexOf(element);
            if (elementIndex != -1)
            {
                RemoveFromIndex((uint)elementIndex);
                //INVARIANTES: El número de elementos en la lista debe ser el mismo al tamaño de esta.
                Invariants();
                //POSTCONDICIONES: Se ha reducido el número de elementos en 1.
                Debug.Assert(previousSize > this.NumberOfElements, "El número de elementos debe de reducirse");                
                return true;
            }
            //INVARIANTES: El número de elementos en la lista debe ser el mismo al tamaño de esta.
            Invariants();            
            return false;
        }

        /// <summary>
        /// Método RemoveFromIndex
        /// Método que elimina de la lista el elemento 
        /// que se encuentra en la posición pasada
        /// por el parámetro:
        /// </summary>
        /// <param name="index"></param>
        private void RemoveFromIndex(uint index)
        {
            if (index == 0)
            {
                this.Head = Head.Next;
            }
            else
            {
                Node previous = GetNode(index - 1);
                previous.Next = previous.Next.Next;
            }
            this.NumberOfElements--;
        }

        /// <summary>
        /// Método GetElement
        /// Método que devuelve el valor del nodo que se encuentra en 
        /// la posición pasada por el parámetro:
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetElement(uint index)
        {
            //PRECONDICIONES: El indice no puede ser mayor o igual al número de elementos.
            if (index >= NumberOfElements)
            {
                throw new ArgumentException("El indice no puede ser mayor o igual al número de elementos");
            }
            //INVARIANTES: El número de elementos en la lista debe ser el mismo al tamaño de esta.
            Invariants();
            return GetNode(index).Value;
        }

        /// <summary>
        /// Método SetElement
        /// Método que modifica el valor del nodo que se encuentra en
        /// la posición pasada por los parámetros:
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        public void SetElement(uint index, T element)
        {            
            //PRECONDICIONES: El indice no puede ser mayor al número de elementos.
            if (index > NumberOfElements)
            {
                throw new ArgumentException("El indice no puede ser mayor al número de elementos");
            }
            //INVARIANTES: El número de elementos en la lista debe ser el mismo al tamaño de esta.
            Invariants();
            if (index == 0)
            {
                this.Head = new Node(element, GetNode(index + 1));
            } else if (index == NumberOfElements - 1)
            {
                GetNode(index - 1).Next = new Node(element, null);
            } else
            {
                GetNode(index - 1).Next = new Node(element, GetNode(index + 1));
            }
            //INVARIANTES: El número de elementos en la lista debe ser el mismo al tamaño de esta.
            Invariants();
            //POSTCONDICIONES: El elemento que se encuentra en la posición del índice es el que se ha pasado por parámetro.
            Debug.Assert(GetElement(index).Equals(element), "El elemento debe estar en la posición correspondiente");            
        }

        /// <summary>
        /// Método GetNode
        /// Método que devuelve el nodo que se encuentra en la posición 
        /// pasada por el parámetro:
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Node GetNode(uint index)
        {
            int currentIndex = 0;
            Node currentNode = Head;
            while (currentIndex < index)
            {
                currentIndex++;
                currentNode = currentNode.Next;
            }
            return currentNode;
        }

        /// <summary>
        /// Método IndexOf
        /// Método que devuelve la posición que ocupa el elemento
        /// pasado por el parámetro:
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public int IndexOf(T element)
        {            
            //PRECONDICIONES: La lista no puede estar vacía.
            if (IsEmpty())
            {
                throw new InvalidOperationException("La lista no puede estar vacía");
            }
            //INVARIANTES: El número de elementos en la lista debe ser el mismo al tamaño de esta.
            Invariants();
            Node currentNode = Head;
            int currentIndex = 0;
            while (currentNode != null && !currentNode.Value.Equals(element))
            {
                currentIndex++;
                currentNode = currentNode.Next;
            }
            //INVARIANTES: El número de elementos en la lista debe ser el mismo al tamaño de esta.
            Invariants();
            return currentNode == null ? -1 : currentIndex;                                  
        }

        /// <summary>
        /// Método Contains
        /// Método que devuelve true si el elemento pasado por parámetro
        /// esta en la lista
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        /// <summary>
        /// Método IsEmpty
        /// Método que devuelve true si la lista está vacía
        /// o false si no lo está.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            //INVARIANTES: El número de elementos en la lista debe ser el mismo al tamaño de esta.
            Invariants();
            return NumberOfElements==0;
        }

        /// <summary>
        /// Método Clear
        /// Método que elimina todos los elementos de la lista
        /// </summary>
        public void Clear()
        {
            //INVARIANTES: El número de elementos en la lista debe ser el mismo al tamaño de esta.
            Invariants();
            this.Head = null;
            this.NumberOfElements = 0;
            //INVARIANTES: El número de elementos en la lista debe ser el mismo al tamaño de esta.
            Invariants();
            //POSTCONDICIONES: La cabeza es null.
            //                 El número de elementos es 0.
            Debug.Assert(this.Head == null, "La cabeza es null");
            Debug.Assert(this.NumberOfElements == 0, "El número de elementos es 0");            
        }

        /// <summary>
        /// Método ToString
        /// Método que devuelve el ToString de la lista enlazada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node currentNode = Head;
            sb.Append("[");
            while (currentNode != null)
            {
                sb.Append($"{currentNode.Value} - ");
                currentNode = currentNode.Next;
            }
            sb.Append("]");
            return sb.ToString();
        }

        //MÉTODOS GENÉRICOS DE ORDEN SUPERIOR
        /// <summary>
        /// Método Find
        /// Método que devuelve el primer elemento que cumpla la condición de la lista
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public T Find(Predicate<T> condition)
        {
            foreach (T element in this)
            {
                if (condition(element))
                {
                    listIterator.Reset();
                    return element;
                }
            }
            listIterator.Reset();
            return default;
        }

        /// <summary>
        /// Método Filter
        /// Método que devuelve una lista con los elementos que cumplan la condición de la lista
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<T> Filter(Predicate<T> condition)
        {
            List<T> filteredList = new List<T>();
            foreach(T element in this)
            {
                if (condition(element))
                {
                    filteredList.Add(element);
                }
            }
            listIterator.Reset();
            return filteredList;
        }

        /// <summary>
        /// Método Reduce
        /// Método que devuelve lo que se haya pedido de la colección
        /// </summary>
        /// <typeparam name="TS"></typeparam>
        /// <param name="function"></param>
        /// <param name="optional"></param>
        /// <returns></returns>
        public TS Reduce<TS>(Func<TS, T, TS> function, TS optional = default)
        {
            TS result = optional;
            foreach(T element in this)
            {
                result = function(result, element);
            }
            listIterator.Reset();
            return result;
        }

        /// <summary>
        /// Método Invert
        /// Método que devuelve la lista invertida
        /// </summary>
        /// <returns></returns>
        public List<T> Invert()
        {
            List<T> invertedList = new List<T>();
            foreach(T element in this)
            {
                invertedList.AddByIndex(0, element);
            }
            listIterator.Reset();
            return invertedList;
        }

        /// <summary>
        /// Método Map
        /// Método que devuelve una lista con otro tipo tras aplicarle la función
        /// </summary>
        /// <typeparam name="TS"></typeparam>
        /// <param name="function"></param>
        /// <returns></returns>
        public List<TS> Map<TS>(Func<T, TS> function)
        {
            List<TS> mappedList = new List<TS>();
            foreach(T element in this)
            {
                mappedList.Add(function(element));
            }
            listIterator.Reset();
            return mappedList;
        }

        /// <summary>
        /// Método ForEach
        /// Método que aplica una acción a cada elemento de la lista
        /// </summary>
        /// <param name="action"></param>
        public void ForEach(Action<T> action) 
        { 
            foreach(T element in this)
            {
                action(element);
            }
            listIterator.Reset();
        }

        //IMPLEMENTACIÓN DE IENUMERABLE
        /// <summary>
        /// Método GetEnumerator
        /// Método que devuelve el enumerador genérico
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new ListIterator(Head);
        }

        /// <summary>
        /// Método GetEnumerator
        /// Método que devuelve el enumerador polimórfico
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ListIterator(Head);
        }

        /// <summary>
        /// Clase ListIterator
        /// Clase iterador de la lista
        /// </summary>
        internal class ListIterator : IEnumerator<T>
        {
            /// <summary>
            /// Atributos head, tail
            /// </summary>
            private Node head, tail;

            /// <summary>
            /// Propiedad Current
            /// Propiedad genérica que devuelve el valor del nodo actual
            /// </summary>
            T IEnumerator<T>.Current
            {
                get { return tail.Value; }
            }

            /// <summary>
            /// Propiedad Current
            /// Propiedad polifórmica que devuelve el valor del nodo actual
            /// </summary>
            object IEnumerator.Current
            {
                get { return tail.Value; }
            }

            /// <summary>
            /// Constructor ListIterator
            /// Constructor que crea el iterador de la lista
            /// </summary>
            /// <param name="head"></param>
            public ListIterator(Node head)
            {
                this.head = head;
                Reset();
            }            

            /// <summary>
            /// Método MoveNext
            /// Método que comprueba si se puede mover a la siguiente posición, y,
            /// de ser así, lo mueve
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                if (tail != null)
                {
                    if (tail.Next == null)
                    {
                        return false;
                    }
                    tail = tail.Next;
                    return true;
                } else
                {
                    tail = head;
                    return true;
                }                
            }

            /// <summary>
            /// Método Reset
            /// Método que resetea el iterador
            /// </summary>
            public void Reset()
            {
                tail = null;
            }

            /// <summary>
            /// Método Dispose
            /// Método que cierra el iterador
            /// </summary>
            public void Dispose()
            {
            }
        }

        /// <summary>
        /// Clase Interna Node:
        /// Cada elemento de la lista es un nodo, que está formado por
        /// el valor de dicho elemento y el siguiente objeto al que apunta.
        /// </summary>
        internal class Node
        {
            /// <summary>
            /// Propiedad Value
            /// Valor del nodo
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// Propiedad Next
            /// Siguiente nodo
            /// </summary>
            public Node Next { get; set; }

            /// <summary>
            /// Constructor Node
            /// Constructor de la clase con los siguientes parámetros:
            /// </summary>
            /// <param name="value"></param>
            /// <param name="next"></param>
            public Node (T value, Node next)
            {
                this.Value = value;
                this.Next = next;
            }
        }

        //INVARIANTES:
        /// <summary>
        /// Método Invariants
        /// Método que llama a las invariantes
        /// </summary>
        private void Invariants()
        {
            Debug.Assert(CheckSize(), "El número de elementos en la lista debe ser el mismo al tamaño de esta.");
        }

        /// <summary>
        /// Método CheckSize
        /// Método que comprueba que el tamaño de la lista corresponde
        /// al número de elementos
        /// </summary>
        /// <returns></returns>
        public bool CheckSize()
        {
            int currentSize = 0;
            Node currentNode = Head;
            while (currentNode != null)
            {
                currentNode = currentNode.Next;
                currentSize++;
            }
            return currentSize == NumberOfElements;
        }
    }
}
