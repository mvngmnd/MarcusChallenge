using System.Collections.Generic;
using System.Collections;

namespace ServersideTests.Test.Unit
{
    public class BankHelperTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1000, "One thousand" };
            yield return new object[] { 1100, "One thousand one hundred" };
            yield return new object[] { 10, "Ten" };
            yield return new object[] { 1234, "One thousand two hundred and thirty four" };
            yield return new object[] { 4321, "Four thousand three hundred and twenty one" };
            yield return new object[] { 4300, "Four thousand three hundred" };
            yield return new object[] { 4301, "Four thousand three hundred and one" };
            yield return new object[] { 4310, "Four thousand three hundred and ten" };
            yield return new object[] { 4021, "Four thousand and twenty one" };
            yield return new object[] { 4007, "Four thousand and seven" };
            yield return new object[] { 41301, "Forty one thousand three hundred and one" };
            yield return new object[] { 410301, "Four hundred and ten thousand three hundred and one" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
