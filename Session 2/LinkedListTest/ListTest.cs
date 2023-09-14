using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPP.Laboratory.ObjectOrientation.Lab02
{
    /// <summary>
    /// Clase ListTest
    /// Clase de pruebas para la lista enlazada
    /// </summary>
    [TestClass]
    public class ListTest
    {
        //TEST DE STRING:
        /// <summary>
        /// Test StringAddTest
        /// </summary>
        [TestMethod]
        public void StringAddTest()
        {
            List list = new List();
            list.Add("Hola");
            list.Add("esto");
            list.Add("es");
            list.Add("una");
            list.Add("prueba");
            Assert.AreEqual((uint)5, list.NumberOfElements);
            Assert.AreEqual("[Hola - esto - es - una - prueba - ]", list.ToString());
        }

        /// <summary>
        /// Test StringRemoveTest
        /// </summary>
        [TestMethod]
        public void StringRemoveTest()
        {
            List list = new List();
            list.Add("Hola");
            list.Add("esto");
            list.Add("es");
            list.Add("una");
            list.Add("prueba");
            Assert.IsTrue(list.Remove("Hola"));
            Assert.IsTrue(list.Remove("es"));
            Assert.IsTrue(list.Remove("prueba"));
            Assert.IsFalse(list.Remove("Hola"));
            Assert.AreEqual((uint)2, list.NumberOfElements);
            Assert.AreEqual("[esto - una - ]", list.ToString());
        }

        /// <summary>
        /// Test StringGetElementTest
        /// </summary>
        [TestMethod]
        public void StringGetElementTest()
        {
            List list = new List();
            list.Add("Hola");
            list.Add("esto");
            list.Add("es");
            list.Add("una");
            list.Add("prueba");
            Assert.AreEqual("Hola", list.GetElement(0));
            Assert.AreEqual("prueba", list.GetElement(4));
            Assert.AreEqual((uint)5, list.NumberOfElements);
            Assert.AreEqual("[Hola - esto - es - una - prueba - ]", list.ToString());
        }

        /// <summary>
        /// Test StringGeneralTest
        /// </summary>
        [TestMethod]
        public void StringGeneralTest()
        {
            List list = new List();
            list.Add("Hola");
            list.Add("esto");
            list.Add("es");
            list.Add("una");
            list.Add("prueba");
            Assert.IsFalse(list.IsEmpty());
            Assert.AreEqual((uint)5, list.NumberOfElements);
            Assert.AreEqual("Hola", list.GetElement(0));
            Assert.AreEqual("prueba", list.GetElement(4));
            Assert.IsTrue(list.Contains("Hola"));
            Assert.IsTrue(list.Remove("Hola"));
            Assert.IsFalse(list.Contains("Hola"));
            Assert.IsTrue(list.Remove("es"));
            Assert.IsTrue(list.Remove("prueba"));
            list.SetElement(0, "Hola");
            list.SetElement(1, "adiós");
            Assert.IsTrue(list.Contains("Hola"));
            Assert.AreEqual((uint)2, list.NumberOfElements);
            Assert.AreEqual("[Hola - adiós - ]", list.ToString());
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual((uint)0, list.NumberOfElements);
            Assert.AreEqual("[]", list.ToString());
        }

        //TEST DE PERSON:
        /// <summary>
        /// Test PersonAddTest
        /// </summary>
        [TestMethod]
        public void PersonAddTest()
        {
            Person alba = new Person("Alba", "Francos", "1");
            Person omar = new Person("Omar", "Teixeira", "2");
            Person israel = new Person("Israel", "Solís", "3");
            Person guillermo = new Person("Guillermo", "Pulido", "4");

            List list = new List();            
            list.Add(alba);
            list.Add(omar);
            list.Add(israel);
            list.Add(guillermo);            
            Assert.AreEqual((uint)4, list.NumberOfElements);
            Assert.AreEqual("[Alba Francos, with 1 ID number - Omar Teixeira, with 2 ID number - " +
                "Israel Solís, with 3 ID number - Guillermo Pulido, with 4 ID number - ]", list.ToString());
        }

        /// <summary>
        /// Test PersonRemoveTest
        /// </summary>
        [TestMethod]
        public void PersonRemoveTest()
        {
            Person alba = new Person("Alba", "Francos", "1");
            Person omar = new Person("Omar", "Teixeira", "2");
            Person israel = new Person("Israel", "Solís", "3");
            Person guillermo = new Person("Guillermo", "Pulido", "4");

            List list = new List();
            list.Add(alba);
            list.Add(omar);
            list.Add(israel);
            list.Add(guillermo);
            Assert.AreEqual((uint)4, list.NumberOfElements);
            Assert.IsTrue(list.Remove(israel));            
            Assert.IsTrue(list.Remove(guillermo));
            Assert.IsFalse(list.Remove(guillermo));
            Assert.AreEqual((uint)2, list.NumberOfElements);
            Assert.AreEqual("[Alba Francos, with 1 ID number - Omar Teixeira, with 2 ID number - ]", list.ToString());
        }

        /// <summary>
        /// Test PersonGetElementTest
        /// </summary>
        [TestMethod]
        public void PersonGetElementTest()
        {
            Person alba = new Person("Alba", "Francos", "1");
            Person omar = new Person("Omar", "Teixeira", "2");
            Person israel = new Person("Israel", "Solís", "3");
            Person guillermo = new Person("Guillermo", "Pulido", "4");

            List list = new List();
            list.Add(alba);
            list.Add(omar);
            list.Add(israel);
            list.Add(guillermo);
            Assert.AreEqual(alba, list.GetElement(0));
            Assert.AreEqual(omar, list.GetElement(1));
            Assert.AreEqual((uint)4, list.NumberOfElements);
            Assert.AreEqual("[Alba Francos, with 1 ID number - Omar Teixeira, with 2 ID number - " +
                "Israel Solís, with 3 ID number - Guillermo Pulido, with 4 ID number - ]", list.ToString());            
        }

        /// <summary>
        /// Test PersonGeneralTest
        /// </summary>
        [TestMethod]
        public void PersonGeneralTest()
        {

            Person alba = new Person("Alba", "Francos", "1");
            Person omar = new Person("Omar", "Teixeira", "2");
            Person israel = new Person("Israel", "Solís", "3");
            Person guillermo = new Person("Guillermo", "Pulido", "4");

            List list = new List();
            list.Add(alba);
            list.Add(omar);
            list.Add(israel);
            list.Add(guillermo);
            Assert.IsFalse(list.IsEmpty());
            Assert.AreEqual((uint)4, list.NumberOfElements);
            Assert.AreEqual(alba, list.GetElement(0));
            Assert.AreEqual(omar, list.GetElement(1));
            Assert.IsTrue(list.Contains(alba));
            Assert.IsTrue(list.Remove(alba));
            Assert.IsFalse(list.Contains(alba));
            Assert.IsTrue(list.Remove(omar));            
            list.SetElement(0, alba);
            list.SetElement(1, omar);
            Assert.IsTrue(list.Contains(alba));
            Assert.AreEqual((uint)2, list.NumberOfElements);
            Assert.AreEqual("[Alba Francos, with 1 ID number - Omar Teixeira, with 2 ID number - ]", list.ToString());
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual((uint)0, list.NumberOfElements);
            Assert.AreEqual("[]", list.ToString());
        }

        //TEST DE INT:
        /// <summary>
        /// Test IntAddTest
        /// </summary>
        [TestMethod]
        public void IntAddTest()
        {
            List list = new List();
            list.Add(1);
            list.Add(8);
            list.Add(0);
            list.Add(6);
            list.Add(2);
            list.Add(0);
            list.Add(1);
            list.Add(9);
            Assert.AreEqual((uint)8, list.NumberOfElements);
            Assert.AreEqual("[1 - 8 - 0 - 6 - 2 - 0 - 1 - 9 - ]", list.ToString());
        }

        /// <summary>
        /// Test IntRemoveTest
        /// </summary>
        [TestMethod]
        public void IntRemoveTest()
        {
            List list = new List();
            list.Add(1);
            list.Add(8);
            list.Add(0);
            list.Add(6);
            list.Add(2);
            list.Add(0);
            list.Add(1);
            list.Add(9);
            Assert.IsTrue(list.Remove(2));
            Assert.IsTrue(list.Remove(0));
            Assert.IsTrue(list.Remove(0));
            Assert.IsFalse(list.Remove(0));
            Assert.AreEqual((uint)5, list.NumberOfElements);
            Assert.AreEqual("[1 - 8 - 6 - 1 - 9 - ]", list.ToString());
        }

        /// <summary>
        /// Test IntGetElementTest
        /// </summary>
        [TestMethod]
        public void IntGetElementTest()
        {
            List list = new List();
            list.Add(1);
            list.Add(8);
            list.Add(0);
            list.Add(6);
            list.Add(2);
            list.Add(0);
            list.Add(1);
            list.Add(9);
            Assert.AreEqual(1, list.GetElement(0));
            Assert.AreEqual(8, list.GetElement(1));
            Assert.AreEqual(0, list.GetElement(2));
            Assert.AreEqual(6, list.GetElement(3));
            Assert.AreEqual((uint)8, list.NumberOfElements);
            Assert.AreEqual("[1 - 8 - 0 - 6 - 2 - 0 - 1 - 9 - ]", list.ToString());
        }

        /// <summary>
        /// Test IntGeneralTest
        /// </summary>
        [TestMethod]
        public void IntGeneralTest()
        {
            List list = new List();
            list.Add(1);
            list.Add(8);
            list.Add(0);
            list.Add(6);
            list.Add(2);
            list.Add(0);
            list.Add(1);
            list.Add(9);
            Assert.IsFalse(list.IsEmpty());
            Assert.AreEqual((uint)8, list.NumberOfElements);
            Assert.AreEqual(1, list.GetElement(0));
            Assert.AreEqual(8, list.GetElement(1));
            Assert.AreEqual(0, list.GetElement(2));
            Assert.AreEqual(6, list.GetElement(3));
            Assert.IsTrue(list.Contains(2));
            Assert.IsTrue(list.Remove(2));
            Assert.IsFalse(list.Contains(2));
            Assert.IsTrue(list.Remove(1));
            Assert.IsTrue(list.Remove(8));
            Assert.IsTrue(list.Remove(0));
            Assert.IsTrue(list.Remove(6));
            Assert.IsTrue(list.Remove(0));
            list.SetElement(0, 1);
            list.SetElement(1, 8);
            Assert.IsTrue(list.Contains(1));
            Assert.AreEqual((uint)2, list.NumberOfElements);
            Assert.AreEqual("[1 - 8 - ]", list.ToString());
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual((uint)0, list.NumberOfElements);
            Assert.AreEqual("[]", list.ToString());
        }

        //TEST DE DOUBLE:
        /// <summary>
        /// Test DoubleAddTest
        /// </summary>
        [TestMethod]
        public void DoubleAddTest()
        {
            List list = new List();
            list.Add(1.8);
            list.Add(0.6);
            list.Add(2.019);
            Assert.AreEqual((uint)3, list.NumberOfElements);
            Assert.AreEqual("[1,8 - 0,6 - 2,019 - ]", list.ToString());            
        }

        /// <summary>
        /// Test DoubleRemoveTest
        /// </summary>
        [TestMethod]
        public void DoubleRemoveTest()
        {
            List list = new List();
            list.Add(1.8);
            list.Add(0.6);
            list.Add(2.019);
            Assert.IsTrue(list.Remove(2.019));
            Assert.IsTrue(list.Remove(0.6));
            Assert.IsFalse(list.Remove(0.6));
            Assert.AreEqual((uint)1, list.NumberOfElements);
            Assert.AreEqual("[1,8 - ]", list.ToString());
        }

        /// <summary>
        /// Test DoubleGetElementTest
        /// </summary>
        [TestMethod]
        public void DoubleGetElementTest()
        {
            List list = new List();
            list.Add(1.8);
            list.Add(0.6);
            list.Add(2.019);
            Assert.AreEqual(1.8, list.GetElement(0));
            Assert.AreEqual(0.6, list.GetElement(1));
            Assert.AreEqual((uint)3, list.NumberOfElements);
            Assert.AreEqual("[1,8 - 0,6 - 2,019 - ]", list.ToString());
        }

        /// <summary>
        /// Test DoubleGeneralTest
        /// </summary>
        [TestMethod]
        public void DoubleGeneralTest()
        {
            List list = new List();
            list.Add(1.8);
            list.Add(0.6);
            list.Add(2.019);
            Assert.IsFalse(list.IsEmpty());
            Assert.AreEqual((uint)3, list.NumberOfElements);
            Assert.AreEqual(1.8, list.GetElement(0));
            Assert.AreEqual(0.6, list.GetElement(1));
            Assert.IsTrue(list.Contains(2.019));
            Assert.IsTrue(list.Remove(2.019));
            Assert.IsFalse(list.Contains(2.019));
            Assert.IsTrue(list.Remove(0.6));
            list.SetElement(0, 1.8);            
            Assert.IsTrue(list.Contains(1.8));
            Assert.AreEqual((uint)1, list.NumberOfElements);
            Assert.AreEqual("[1,8 - ]", list.ToString());
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual((uint)0, list.NumberOfElements);
            Assert.AreEqual("[]", list.ToString());
        }

    }
}
