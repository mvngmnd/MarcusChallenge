using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using TechOne.Controllers;
using System;

namespace ServersideTests.Test.Unit
{
    public class BankControllerIntegrationTests
    {
        [Theory]
        [ClassData(typeof(BankControllerTestData))]
        public void BankControllerPositiveTests(string value, string expected)
        {
            var mockLogger = new Mock<ILogger<BankController>>();
            var controller = new BankController(mockLogger.Object);

            var result = controller.ConvertToString(value);

            Assert.Equal(expected.ToLower(), result.ToLower());
        }

        [Theory]
        [ClassData(typeof(BankControllerTestDataFail))]
        public void BankControllerNegativeTests(string value)
        {
            var mockLogger = new Mock<ILogger<BankController>>();

            var controller = new BankController(mockLogger.Object) { 
                ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext()
            }; 
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            Assert.Throws<ArgumentException>(() => controller.ConvertToString(value));
        }
    }
}

