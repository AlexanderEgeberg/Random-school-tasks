using Microsoft.VisualStudio.TestTools.UnitTesting;
using CovidExam.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CovidExam.Controllers.Tests
{
    [TestClass()]
    public class CovidRecordsControllerTests
    {
        [TestMethod()]
        public async Task getCovidRecordTest()
        {
            var options = new DbContextOptionsBuilder<CovidRecordContext>()
                .UseInMemoryDatabase(databaseName: "Covid Record").Options;

            using (var context = new CovidRecordContext(options))
            {
                context.CovidRecords.Add(new CovidRecord("roskilde", 3, 4, 5));

                context.SaveChanges();
            }

            using (var context = new CovidRecordContext(options))
            {
                CovidRecordsController controller = new CovidRecordsController(context);
                var result = await controller.GetCovidRecordHousehold(9);
                var actualresult = result.Value;

                Assert.AreEqual(3,actualresult);
            }
        }
    }
}