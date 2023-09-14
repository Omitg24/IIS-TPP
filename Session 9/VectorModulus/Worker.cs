
namespace TPP.Laboratory.Concurrency.Lab09 
{
    /// <summary>
    /// Clase Worker
    /// </summary>
    internal class Worker {
        /// <summary>
        /// Atributo vector
        /// </summary>
        private short[] vector;

        /// <summary>
        /// Atributos fromIndex, toIndex
        /// </summary>
        private int fromIndex, toIndex;

        /// <summary>
        /// Atributo result
        /// </summary>
        private long result;

        /// <summary>
        /// Propiedad Result
        /// </summary>
        internal long Result {
            get { return this.result; }
        }

        /// <summary>
        /// Constructor Worker
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="fromIndex"></param>
        /// <param name="toIndex"></param>
        internal Worker(short[] vector, int fromIndex, int toIndex) {
            this.vector = vector;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
        }

        /// <summary>
        /// Método Compute
        /// </summary>
        internal void Compute() {
            this.result = 0;
            for (int i = this.fromIndex; i<=this.toIndex; i++)
            {
                this.result += this.vector[i] * this.vector[i];
            }
        }
    }
}
