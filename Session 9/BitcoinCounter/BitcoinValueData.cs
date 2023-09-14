using System;

namespace TPP.Laboratory.Concurrency.Lab09
{
    /// <summary>
    /// Clase BitcoinValueData
    /// </summary>
    public class BitcoinValueData
    {
        /// <summary>
        /// Propiedad Timestampt
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Propiedad Value
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Método ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Timestamp + ": " + Value;
        }
    }
}
