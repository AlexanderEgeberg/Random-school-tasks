using Microsoft.VisualStudio.TestTools.UnitTesting;
using library;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace library.Tests
{
    [TestClass()]
    public class CovidRecordTests
    {
        private CovidRecord _record;

        [TestInitialize]
        public void BeforeTest()
        {
            _record = new CovidRecord(1,"jyllinge",2,1,1);
        }

        [TestMethod()]
        public void constructorTest()
        {
            try
            {
                CovidRecord test = new CovidRecord(2,"a", 0, -1, -1);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("mindst 2 tegn", ex.Message);
            }
        }

        [TestMethod()]
        public void CityTest()
        {
            Assert.AreEqual("jyllinge", _record.City);

            try
            {
                _record.City = "A";
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("mindst 2 tegn", ex.Message);
            }
        }

        [TestMethod()]
        public void HouseholdTest()
        {
            Assert.AreEqual(2, _record.Household);

            try
            {
                _record.Household = 0;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("mindst 1 medlem", ex.Message);
            }

            _record.Household = 1;
            Assert.AreEqual(1, _record.Household);
        }

        [TestMethod()]
        public void TestedTest()
        {
            Assert.AreEqual(1, _record.Tested);

            try
            {
                _record.Tested = -1;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("mindst 0 tested", ex.Message);
            }

            _record.Tested = 0;
            Assert.AreEqual(0, _record.Tested);
        }

        [TestMethod()]
        public void SickTest()
        {
            Assert.AreEqual(1, _record.Sick);

            _record.Sick = 0;
            Assert.AreEqual(0, _record.Sick);

            try
            {
                _record.Sick = -1;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("mindst 0 syge", ex.Message);
            }

        }

    }
}