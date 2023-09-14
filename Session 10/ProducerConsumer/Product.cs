using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP.Laboratory.Concurrency.Lab10
{
    /// <summary>
    /// Clase Product
    /// </summary>
    class Product
    {
        /// <summary>
        /// Propiedad ProductID
        /// </summary>
        public int ProductID { get; private set; }

        /// <summary>
        /// Constructor Product
        /// </summary>
        /// <param name="productID"></param>
        public Product(int productID)
        {
            ProductID = productID;
        }

        /// <summary>
        /// Método ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Product {0}", ProductID);
        }
    }
}
