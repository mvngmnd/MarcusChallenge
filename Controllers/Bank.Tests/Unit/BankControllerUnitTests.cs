using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using TechOne.Controllers;

namespace ServersideTests.Test.Unit
{
    public class BankControllerUnitTests
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
    }
}

