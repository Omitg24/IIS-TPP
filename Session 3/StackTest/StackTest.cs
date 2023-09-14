using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TPP.Laboratory.ObjectOrientation.Lab03
{
    /// <summary>
    /// Clase StackTest
    /// Clase de pruebas para la pila
    /// </summary>
    [TestClass]
    public class StackTest
    {
        //TESTS GENERALES:
        /// <summary>
        /// Test PushTest
        /// </summary>
        [TestMethod]
        public void PushTest()
        {
            Stack<int> stack = new Stack<int>(5);
            Assert.IsTrue(stack.IsEmpty);
            Assert.IsFalse(stack.IsFull);
            Assert.AreEqual(1, stack.Push(1));            
            Assert.AreEqual(2, stack.Push(2));
            Assert.AreEqual(3, stack.Push(3));
            Assert.AreEqual(4, stack.Push(4));
            Assert.AreEqual(5, stack.Push(5));
            Assert.IsFalse(stack.IsEmpty);
            Assert.IsTrue(stack.IsFull);
        }

        /// <summary>
        /// Test PopTest
        /// </summary>
        [TestMethod]
        public void PopTest()
        {
            Stack<int> stack = new Stack<int>(5);
            Assert.AreEqual(1, stack.Push(1));
            Assert.AreEqual(2, stack.Push(2));
            Assert.AreEqual(3, stack.Push(3));
            Assert.AreEqual(4, stack.Push(4));
            Assert.AreEqual(5, stack.Push(5));
            Assert.IsTrue(stack.IsFull);
            Assert.AreEqual(5, stack.Pop());
            Assert.IsFalse(stack.IsFull);
            Assert.AreEqual(4, stack.Pop());
            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
            Assert.IsTrue(stack.IsEmpty);
            Assert.IsFalse(stack.IsFull);
        }

        //TESTS DE EXCEPCIONES:
        /// <summary>
        /// Test ConstructorExceptionTest
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorExceptionTest()
        {
            new Stack<int>(0);
        }

        /// <summary>
        /// Test PushExceptionTest
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PushExceptionTest()
        {
            Stack<string> stack = new Stack<string>(5);
            stack.Push(null);
        }

        /// <summary>
        /// Test PopExceptionTest
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopExceptionTest()
        {
            Stack<int> stack = new Stack<int>(5);
            stack.Pop();
        }
    }
}