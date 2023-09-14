namespace TPP.Laboratory.Concurrency.Lab09 
{
    /// <summary>
    /// Clase Worker
    /// </summary>
    internal class Worker {
        /// <summary>
        /// Atributo data
        /// </summary>
        private BitcoinValueData[] data;

        /// <summary>
        /// Atributos from y to
        /// </summary>
        private int from, to;

        /// <summary>
        /// Atributo result
        /// </summary>
        private int result;

        /// <summary>
        /// Atributo limit
        /// </summary>
        private int limit;
        
        /// <summary>
        /// Propiedad Result
        /// </summary>
        public int Result {
            get { return this.result; }
        }

        /// <summary>
        /// Constructor Worker
        /// </summary>
        /// <param name="data"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="limit"></param>
        internal Worker(BitcoinValueData[] data, int from, int to, int limit) {
            this.data = data;
            this.from = from;
            this.to = to;
            this.limit = limit;
        }

        /// <summary>
        /// Método Compute
        /// </summary>
        internal void Compute() {
            this.result = 0;
            for (int i = this.from; i <= this.to; i++)
            {
                if (this.data[i].Value > limit)
                {
                    result++;
                }
            }
        }
    }
}
