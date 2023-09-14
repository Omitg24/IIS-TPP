using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TPP.Laboratory.ObjectOrientation.Lab02
{  
    
    /// <summary>
    /// Class to test the Vector class
    ///</summary>
    [TestClass]
    public class VectorTest {

        /// <summary>
        /// Instance used in most of the tests
        /// </summary>
        private Vector vector;

        /********************** Special semantics testing methods *********************************/

        
        /// <summary>
        /// This class (static) method is run only once, before running any test.
        /// Used for initialization purposes to assign the resoures used by all the tests in this class.
        /// The attribute (annotation) between [] allows using any static method with any name.
        /// It is not necessary to be written if it is not used.
        /// </summary>
        [ClassInitialize]
        public static void InitializeAllTheTests(TestContext testContext) {
        }

        /// <summary>
        /// Method that executed before each single test in this class.
        /// Used to initialize all the tests in the class.
        /// The attribute (annotation) between [] allows using any static method with any name.
        /// It is not necessary to be written if it is not used.
        /// </summary>
        [TestInitialize]
        public void InitializeTests() {
            // * We create an empty vector
            this.vector = new Vector();
        }

        /// <summary>
        /// Method that executed after each single test in this class.
        /// Used to clean up all the tests in the class.
        /// The attribute (annotation) between [] allows using any static method with any name.
        /// It is not necessary to be written if it is not used.
        /// </summary>
        [TestCleanup]
        public void CleanUpTests() {
        }

        /// <summary>
        /// This class (static) method is run only once, after running all the tests.
        /// Used for cleaning up purposes, to release the resources used by all the tests in this class.
        /// The attribute (annotation) between [] allows using any static method with any name.
        /// It is not necessary to be written if it is not used.
        /// </summary>
        [ClassCleanup]
        public static void CleanUpAllTheTests() {
        }

        /********************** Tesing methods *********************************/

        /// <summary>
        /// The public methods with the TestMethod attribute (annotation) are executed as unit tests
        /// </summary>
        [TestMethod]
        public void ConstructorVectorTest() {
            // * The is called in the InitializeTests method
            // * The static methods of the Assert class are used to assert those conditions
            //   that must be true if the code is correct
            Assert.AreEqual(0, this.vector.Size);  // 1st expected value, 2nd actual value
        }

        /// <summary>
        /// Test of Add and GetElement
        /// </summary>
        [TestMethod]
        public void AddTest() {
            const int firstValue = 3, secondValue = -8;
            this.vector.Add(firstValue);
            Assert.AreEqual(1, this.vector.Size); 
            Assert.AreEqual(firstValue, this.vector.GetElement(0));
            this.vector.Add(secondValue);
            Assert.AreEqual(2, this.vector.Size);
            Assert.AreEqual(secondValue, this.vector.GetElement(1));
        }

        /// <summary>
        /// Test of Add and SetElement
        /// </summary>
        [TestMethod]
        public void SetElementTest() {
            this.vector.Add(0);
            this.vector.Add(2);
            const int firstValue = 3, secondValue = -8;
            this.vector.SetElement(0, firstValue);
            this.vector.SetElement(1, secondValue);
            Assert.AreEqual(firstValue, this.vector.GetElement(0));
            Assert.AreEqual(secondValue, this.vector.GetElement(1));
        }

        /// <summary>
        /// Test that checks that GetElement controls the access out of bounds.
        /// The ExpectedException attribute (annotation) checks that the exception
        /// specified as a parameter (ArgumentException) is thrown.
        /// Otherwise, the test is wrong.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetElementOutOfBoundsTest() {
            this.vector.GetElement(0);
        }

        /// <summary>
        /// Test that checks that SetElement controls the access out of bounds.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetElementOutOfBoundsTest() {
            this.vector.Add(0);
            this.vector.SetElement(1, 0);
        }

    }
}
