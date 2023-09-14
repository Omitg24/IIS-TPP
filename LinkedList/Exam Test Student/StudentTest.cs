using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedList;
using TPP.Laboratory.Exam.Test.List;

namespace TPP.Laboratory.Exam.Test.Student
{
    [TestClass]
    public class StudentTest : TestList
    {
        public override dynamic GetList<T>()
        {
            //You must return an instance of your List
            return new List<T>();
        }
    }
}
