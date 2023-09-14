using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TPP.Laboratory.ObjectOrientation.Lab02
{
    /// <summary>
    /// Clase SetTest
    /// Clase de pruebas para el conjunto
    /// </summary>
    [TestClass]
    public class SetTest
    {
        /// <summary>
        /// Test AddTest
        /// </summary>
        [TestMethod]
        public void AddTest()
        {
            Set set = new Set();
            set+=1;
            set+=8;
            set+=0;
            set+=6;
            Assert.AreEqual((uint) 4, set.NumberOfElements);
            Assert.AreEqual("[1 - 8 - 0 - 6 - ]", set.ToString());
        }

        /// <summary>
        /// Test RemoveTest
        /// </summary>
        [TestMethod]
        public void RemoveTest()
        {
            Set set = new Set();
            set+=1;
            set+=8;
            set+=0;
            set+=6;
            Assert.AreEqual((uint)4, set.NumberOfElements);
            set-=0;
            set-=6;
            set-=6;
            Assert.AreEqual((uint)2, set.NumberOfElements);
            Assert.AreEqual("[1 - 8 - ]", set.ToString());
        }

        /// <summary>
        /// Test IndexTest
        /// </summary>
        [TestMethod]
        public void IndexTest()
        {
            Set set = new Set();
            set+=1;
            set+=8;
            set+=0;
            set+=6;            
            Assert.AreEqual(1, set[0]);
            Assert.AreEqual(8, set[1]);
            Assert.AreEqual(0, set[2]);
            Assert.AreEqual(6, set[3]);
            set[2]=1;
            set[3]=9;
            Assert.AreEqual((uint)4, set.NumberOfElements);
            Assert.AreEqual("[1 - 8 - 0 - 9 - ]", set.ToString());
        }

        /// <summary>
        /// Test UnionTest
        /// </summary>
        [TestMethod]
        public void UnionTest()
        {
            Set a = new Set();
            Set b = new Set();
            a+=1;
            a+=2;
            b+=3;
            b+=4;
            Assert.AreEqual((uint)2, a.NumberOfElements);
            Assert.AreEqual((uint)2, b.NumberOfElements);
            Set union = a|b;
            Assert.AreEqual(1, union[0]);
            Assert.AreEqual(2, union[1]);
            Assert.AreEqual(3, union[2]);
            Assert.AreEqual(4, union[3]);
            Assert.AreEqual((uint)4, union.NumberOfElements);
        }

        /// <summary>
        /// Test IntersectionTest
        /// </summary>
        [TestMethod]
        public void IntersectionTest()
        {
            Set a = new Set();
            Set b = new Set();
            a+=1;
            a+=2;
            a+=3;
            b+=2;
            b+=3;
            b+=4;
            Assert.AreEqual((uint)3, a.NumberOfElements);
            Assert.AreEqual((uint)3, b.NumberOfElements);
            Set intersection = a&b;
            Assert.AreEqual(2, intersection[0]);
            Assert.AreEqual(3, intersection[1]);
            Assert.AreEqual((uint)2, intersection.NumberOfElements);
        }

        /// <summary>
        /// Test DifferenceTest
        /// </summary>
        [TestMethod]
        public void DifferenceTest()
        {
            Set a = new Set();
            Set b = new Set();
            a+=1;
            a+=2;
            a+=3;
            b+=2;
            b+=3;
            b+=4;
            Set difference = a-b;
            Assert.AreEqual(1, difference[0]);
            Assert.AreEqual((uint)1, difference.NumberOfElements);
        }

        /// <summary>
        /// Test ContainsTest
        /// </summary>
        [TestMethod]
        public void ContainsTest()
        {
            Set set = new Set();
            set+=1;
            set+=8;
            set+=0;
            set+=6;
            Assert.IsTrue(set^1);
            Assert.IsTrue(set^8);
            Assert.IsTrue(set^0);
            Assert.IsTrue(set^6);
            Assert.IsFalse(set^9);
            set-=0;
            Assert.IsFalse(set^0);
        }

        /// <summary>
        /// Test AddExceptionTest
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddExceptionTest()
        {
            Set set = new Set();
            set+=null;
        }

        /// <summary>
        /// Test RemoveExceptionTest
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveExceptionTest()
        {
            Set set = new Set();
            set-=null;
        }

        /// <summary>
        /// Test UnionExceptionTest
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnionExceptionTest()
        {
            Set set = new Set();
            Set union = set|null;
        }

        /// <summary>
        /// Test IntersecctionExceptionTest
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IntersecctionExceptionTest()
        {
            Set set = new Set();
            Set intersecction = set&null;
        }

        /// <summary>
        /// Test DifferenceExceptionTest
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DifferenceExceptionTest()
        {
            Set set = new Set();
            Set difference = set-null;
        }

        /// <summary>
        /// Test ContainsExceptionTest
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContainsExceptionTest()
        {
            Set set = new Set();
            bool result = set^null;
        }
    }
}
