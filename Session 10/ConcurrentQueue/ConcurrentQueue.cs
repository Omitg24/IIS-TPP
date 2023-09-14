using LinkedList;

namespace TPP.Laboratory.Concurrency.Lab10
{
    /// <summary>
    /// Clase ConcurrentQueue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConcurrentQueue<T>
    {

        /// <summary>
        /// Atributo queue
        /// </summary>
        private List<T> queue;

        /// <summary>
        /// Propiedad NumberOfElements
        /// </summary>
        public uint NumberOfElements { get { return queue.NumberOfElements; } }

        /// <summary>
        /// Propiedad IsEmpty
        /// </summary>
        public bool IsEmpty { get { return NumberOfElements == 0; } }

        /// <summary>
        /// Constructor ConcurrentQueue
        /// </summary>
        public ConcurrentQueue()
        {
            this.queue = new List<T>();
        }

        /// <summary>
        /// Método Enqueue
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public void Enqueue(T element)
        {
            lock (queue)
            {
                this.queue.Add(element);
            }
        }

        /// <summary>
        /// Método Dequeue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            T element;
            lock (queue)
            {
                element = this.queue.GetElement(0);
                this.queue.Remove(element);
            }
            return element;
        }

        /// <summary>
        /// Método Peek
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {            
            lock (queue)
            {
                return this.queue.GetElement(0);
            }
        }

        /// <summary>
        /// Método ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return queue.ToString();
        }
    }
}
