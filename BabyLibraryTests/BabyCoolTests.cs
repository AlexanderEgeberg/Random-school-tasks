using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabyLibrary;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace BabyLibrary.Tests
{
    [TestClass()]
    public class BabyCoolTests
    {

        [TestMethod()]
        public void AlarmCryBreath()
        {
            Assert.AreEqual("kritisk høj", BabyCool.AlarmBreath(19));

            Assert.AreEqual("normal", BabyCool.AlarmBreath(18));

            Assert.AreEqual("normal", BabyCool.AlarmBreath(12));

            Assert.AreEqual("kritisk lav", BabyCool.AlarmBreath(11));

        }

        [TestMethod()]
        public void AlarmCryTest()
        {
            Assert.IsTrue(BabyCool.AlarmCry(1));

            Assert.IsFalse(BabyCool.AlarmCry(2));
            Assert.IsFalse(BabyCool.AlarmCry(0));

        }
    }
}