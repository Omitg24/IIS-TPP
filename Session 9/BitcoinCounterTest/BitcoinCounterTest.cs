using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TPP.Laboratory.Concurrency.Lab09
{
    /// <summary>
    /// Clase BitcoinCounterTest
    /// </summary>
    [TestClass]
    public class BitcoinCounterTest
    {
        /// <summary>
        /// Atributo data
        /// </summary>
        private BitcoinValueData[] data;

        /// <summary>
        /// Método Initialize
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.data = Utils.GetBitcoinData();
        }

        /// <summary>
        /// Método ComputeCount
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        private int ComputeCount(int limit)
        {
            int count = 0;
            foreach(var btc in data)
            {
                if (btc.Value > limit)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Test SingleThreadTest
        /// </summary>
        [TestMethod]
        public void SingleThreadTest()
        {
            int limit = 7000;
            Assert.AreEqual(ComputeCount(limit), new Master(data, 1, limit).ComputeCount());
        }

        /// <summary>
        /// Test FourThreadsTest
        /// </summary>
        [TestMethod]
        public void FourThreadsTest()
        {
            int limit = 7000;
            Assert.AreEqual(ComputeCount(limit), new Master(data, 4, limit).ComputeCount());
        }

        /// <summary>
        /// Test FiftyThreadTest
        /// </summary>
        [TestMethod]
        public void FiftyThreadTest()
        {
            int limit = 7000;
            Assert.AreEqual(ComputeCount(limit), new Master(data, 50, limit).ComputeCount());
        }


        //EXCEPCIONES
        /// <summary>
        /// Test FiftyThreadTest
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DataNullTest()
        {
            int limit = 7000;
            new Master(null, 50, limit);
        }

        /// <summary>
        /// Test FiftyThreadTest
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WrongNumberOfThreadsTest()
        {
            int limit = 7000;
            new Master(data, 0, limit);
        }
    }
}
