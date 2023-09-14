using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPP.Laboratory.Concurrency.Lab10
{
    /// <summary>
    /// Clase ConcurrentQueueTest
    /// </summary>
    [TestClass]
    public class ConcurrentQueueTest
    {
        /// <summary>
        /// Atributo queue
        /// </summary>
        private ConcurrentQueue<int> queue;

        /// <summary>
        /// Método Initialize
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            queue = new ConcurrentQueue<int>();
        }

        /// <summary>
        /// Test EnqueueTest
        /// </summary>
        [TestMethod]
        public void EnqueueTest()
        {
            Assert.IsTrue(queue.IsEmpty);
            queue.Enqueue(1);
            queue.Enqueue(8);
            queue.Enqueue(0);
            queue.Enqueue(6);
            queue.Enqueue(2);
            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(9);
            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(8, (int)queue.NumberOfElements);
            Assert.AreEqual("[1 - 8 - 0 - 6 - 2 - 0 - 1 - 9 - ]", queue.ToString());
        }

        /// <summary>
        /// Test DequeueTest
        /// </summary>
        [TestMethod]
        public void DequeueTest()
        {
            queue.Enqueue(1);
            queue.Enqueue(8);
            queue.Enqueue(0);
            queue.Enqueue(6);
            queue.Enqueue(2);
            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(9);
            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(8, (int)queue.NumberOfElements);
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(8, queue.Dequeue());
            Assert.AreEqual(0, queue.Dequeue());
            Assert.AreEqual(6, queue.Dequeue());
            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(4, (int)queue.NumberOfElements);
            Assert.AreEqual("[2 - 0 - 1 - 9 - ]", queue.ToString());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(0, queue.Dequeue());
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(9, queue.Dequeue());
            Assert.IsTrue(queue.IsEmpty);
            Assert.AreEqual(0, (int)queue.NumberOfElements);
        }

        /// <summary>
        /// Test PeekTest
        /// </summary>
        [TestMethod]
        public void PeekTest()
        {
            queue.Enqueue(1);
            queue.Enqueue(8);
            queue.Enqueue(0);
            queue.Enqueue(6);
            queue.Enqueue(2);
            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(9);
            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(8, queue.Peek());
            Assert.AreEqual(8, queue.Dequeue());
            Assert.AreEqual(0, queue.Peek());
            Assert.AreEqual(0, queue.Peek());
            Assert.AreEqual(0, queue.Dequeue());
            Assert.AreEqual(6, queue.Peek());
            Assert.AreEqual(6, queue.Dequeue());
            Assert.AreEqual(2, queue.Peek());
            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(4, (int)queue.NumberOfElements);
            Assert.AreEqual("[2 - 0 - 1 - 9 - ]", queue.ToString());
        }
    }
}
