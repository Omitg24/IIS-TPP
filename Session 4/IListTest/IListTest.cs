using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TPP.Laboratory.ObjectOrientation.Lab04
{
    /// <summary>
    /// Clase IListTest
    /// </summary>
    [TestClass]
    public class IListTest
    {
        /// <summary>
        /// Test AddTest
        /// </summary>
        [TestMethod]
        public void AddCountTest()
        {
            IList<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(1);
            Assert.AreEqual(4, list.Count);
        }

        /// <summary>
        /// Test GetSetTest
        /// </summary>
        [TestMethod]
        public void GetSetTest()
        {
            IList<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(1);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
            Assert.AreEqual(4, list.Count);
            list[0]=0;
            list[1]=1;
            list[2]=2;
            Assert.AreEqual(0, list[0]);
            Assert.AreEqual(1, list[1]);
            Assert.AreEqual(2, list[2]);
            Assert.AreEqual(4, list.Count);
        }

        /// <summary>
        /// Test ContainsTest
        /// </summary>
        [TestMethod]
        public void ContainsTest()
        {
            IList<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(1);
            Assert.IsTrue(list.Contains(1));
            Assert.IsTrue(list.Contains(2));
            Assert.IsTrue(list.Contains(3));
            Assert.IsFalse(list.Contains(4));
        }

        /// <summary>
        /// Test IndexOfTest
        /// </summary>
        [TestMethod]
        public void IndexOfTest()
        {
            IList<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(1);
            Assert.AreEqual(0, list.IndexOf(1));
            Assert.AreEqual(1, list.IndexOf(2));
            Assert.AreEqual(2, list.IndexOf(3));
            Assert.AreEqual(-1, list.IndexOf(4));
            Assert.AreEqual(0, list.IndexOf(1));
        }

        /// <summary>
        /// Test RemoveTest
        /// </summary>
        [TestMethod]
        public void RemoveTest()
        {
            IList<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(1);
            Assert.AreEqual(4, list.Count);
            Assert.IsTrue(list.Remove(1));
            Assert.AreEqual(3, list.Count);
            Assert.IsTrue(list.Remove(1));
            Assert.AreEqual(2, list.Count);
            Assert.IsTrue(list.Remove(2));
            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(list.Remove(2));
            Assert.AreEqual(1, list.Count);
            Assert.IsTrue(list.Remove(3));
            Assert.AreEqual(0, list.Count);
            Assert.IsFalse(list.Remove(3));
            Assert.IsFalse(list.Remove(1));
            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Test ForeachTest
        /// </summary>
        [TestMethod]
        public void ForeachTest()
        {
            IList<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);

            int counter = 1;
            foreach(int item in list)
            {
                Assert.AreEqual(counter, item);
                counter++;
            }
        }
    }
}
