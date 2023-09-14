using System.Text;

namespace TPP.Laboratory.ObjectOrientation.Lab02
{
    /// <summary>
    /// Clase List
    /// Implementación de la lista enlazada
    /// </summary>
    public class List
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
        /// Método Add
        /// Método que añade a la lista el elemento pasado por
        /// el parámetro:
        /// </summary>
        /// <param name="element"></param>
        public void Add(object element)
        {
            if (IsEmpty())
            {
                this.Head = new Node(element, null);
                this.NumberOfElements++;
            }
            else
            {
                Node last = GetNode(NumberOfElements - 1);
                last.Next = new Node(element, null);
                this.NumberOfElements++;
            }
        }

        /// <summary>
        /// Método Remove
        /// Método que elimina de la lista el elemento
        /// pasado por el parámetro:
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Remove(object element)
        {
            int elementIndex = IndexOf(element);
            if (elementIndex != -1)
            {
                RemoveFromIndex((uint) elementIndex);
                return true;
            }
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
            } else
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
        public object GetElement(uint index)
        {            
            return GetNode(index).Value;
        }

        /// <summary>
        /// Método SetElement
        /// Método que modifica el valor del nodo que se encuentra en
        /// la posición pasada por los parámetros:
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        public void SetElement(uint index, object element)
        {
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
            uint currentIndex = 0;
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
        public int IndexOf(object element)
        {
            Node currentNode = Head;
            uint currentIndex = 0;
            while (currentNode != null && !currentNode.Value.Equals(element))
            {
                currentIndex++;
                currentNode = currentNode.Next;                
            }
            return currentNode == null ? -1 : (int) currentIndex;
        }

        /// <summary>
        /// Método Contains
        /// Método que devuelve true si el elemento pasado por parámetro
        /// esta en la lista
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Contains(object element)
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
            return NumberOfElements==0;
        }

        /// <summary>
        /// Método Clear
        /// Método que elimina todos los elementos de la lista
        /// </summary>
        public void Clear()
        {
            this.Head = null;
            this.NumberOfElements = 0;
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
            public object Value { get; set; }

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
            public Node (object value, Node next)
            {
                this.Value = value;
                this.Next = next;
            }
        }
    }
}
