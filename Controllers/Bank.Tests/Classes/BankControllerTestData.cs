using System.Collections.Generic;
using System.Collections;

namespace ServersideTests.Test.Unit
{
    public class BankControllerTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "1000.02", "One thousand dollars and two cents" };
            yield return new object[] { "0.02", "Zero dollars and Two cents" };
            yield return new object[] { "123.01", "One hundred and twenty three dollars and One cent" };
            yield return new object[] { "31.1", "Thirty one dollars and Ten cents" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
