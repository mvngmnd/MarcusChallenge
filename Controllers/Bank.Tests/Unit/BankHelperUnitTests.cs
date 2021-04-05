using Xunit;
using TechOne.Controllers;

namespace ServersideTests.Test.Unit
{
    public class BankHelperUnitTests
    {
        [Theory]
        [ClassData(typeof(BankHelperTestData))]
        public void NumberToStringTests(ulong value, string expected)
        {
            var result = BankHelper.NumberToString(value);
            Assert.Equal(expected.ToLower(), result.ToLower());
        }
    }
}

