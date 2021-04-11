using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DepartmentsAndSeals.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InfiniteCycleRemark()
        {
            Department d1 = new Department(1, 1, 2, 2, true, false);
            Department d2 = new Department(2, 2, 1, 1);
            Department d3 = new Department(3, 1, 2, 1, false, true);
            List<Department> departments = new List<Department>();
            departments.Add(d1); departments.Add(d2); departments.Add(d3);
            Blank blank = new Blank();
            List<Blank> result = blank.GetBlank(d1,departments, out string remark);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("1, ",result[0].ToStr());
            Assert.AreEqual(" Бесконечный цикл ", remark);
        }

        [TestMethod]
        public void ZeroTimesRemark()
        {
            Department d1 = new Department(1, 1, 2, 3, 2, 3, 2, 3, true, false);
            Department d2 = new Department(2, 2, 1, 3);
            Department d3 = new Department(3, 1, 2, 1, false, true);
            List<Department> departments = new List<Department>();
            departments.Add(d1); departments.Add(d2); departments.Add(d3);
            Blank blank = new Blank();
            List<Blank> result1 = blank.GetBlank(d2, departments, out string remark1);

            Assert.AreEqual(0, result1.Count);
            Assert.AreEqual(" Ни разу не были в этом отделе ", remark1);
        }

        public void InfiniteCycleAndInfiniteCycleRemarks()
        {
            Department d1 = new Department(1, 1, 2, 2, true, false);
            Department d2 = new Department(2, 2, 1, 1);
            Department d3 = new Department(3, 1, 2, 1, false, true);
            List<Department> departments = new List<Department>();
            departments.Add(d1); departments.Add(d2); departments.Add(d3);
            Blank blank = new Blank();
            List<Blank> result = blank.GetBlank(d3, departments, out string remark);

            Assert.AreEqual(" Бесконечный цикл  Ни разу не были в этом отделе ", remark);
        }

        [TestMethod]
        public void TwoDeps()
        {
            Department d1 = new Department(1, 1, 2, 2, true, false);
            Department d2 = new Department(2, 2, 1, 1, false, true);
            List<Department> departments = new List<Department>();
            departments.Add(d1); departments.Add(d2); 
            Blank blank = new Blank();
            List<Blank> result = blank.GetBlank(d1, departments, out string remark);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("1, ", result[0].ToStr());
            Assert.AreEqual("", remark);
        }

        [TestMethod]
        public void Condition()
        {
            Department d1 = new Department(1, 1, 2, 3, 2, 3, 2, 3, true, false);
            Department d2 = new Department(2, 2, 1, 3);
            Department d3 = new Department(3, 1, 2, 1, false, true);
            List<Department> departments = new List<Department>();
            departments.Add(d1); departments.Add(d2); departments.Add(d3);
            Blank blank = new Blank();
            List<Blank> result1 = blank.GetBlank(d1, departments, out string remark1);

            Assert.AreEqual(1, result1.Count);
            Assert.AreEqual("3, ", result1[0].ToStr());
            Assert.AreEqual("", remark1);
        }

        [TestMethod]
        public void CycleOneTime()
        {
            Department d1 = new Department(1, 1, 3, 2, 3, 2, 1, 2, true, false);
            Department d2 = new Department(2, 1, 2, 1);
            Department d3 = new Department(3, 1, 2, 1, false, true);
            List<Department> departments = new List<Department>();
            departments.Add(d1); departments.Add(d2); departments.Add(d3);
            Blank blank = new Blank();
            List<Blank> result1 = blank.GetBlank(d1, departments, out string remark);

            Assert.AreEqual(2, result1.Count);
            Assert.AreEqual("2, ", result1[0].ToStr());
            Assert.AreEqual("1, 3, ", result1[1].ToStr());
        }

        [TestMethod]
        public void DifferentToDepSameSeals()
        {
            Department d1 = new Department(1, 1, 100, 3, true, false);
            Department d2 = new Department(2, 3, 1, 3);
            Department d3 = new Department(3, 1, 2, 3, 2, 1, 3, 4);
            Department d4 = new Department(4, 100, 101, 3, false, true);
            List<Department> departments = new List<Department>();
            departments.Add(d1); departments.Add(d2); departments.Add(d3); departments.Add(d4);
            Blank blank = new Blank();
            List<Blank> result = blank.GetBlank(d3, departments, out string remark);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("1, 2, ", result[0].ToStr());
            //Assert.AreEqual("2, 1, ", result[1].ToStr());
            Assert.AreEqual("", remark);
        }
    }
}
