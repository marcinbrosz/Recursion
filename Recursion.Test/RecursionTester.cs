using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion.Test
{
    [TestFixture]
    public class RecursionTester
    {
        [Test]
        public void BasicTest()
        {

            Assert.AreEqual(1, Library.Recursion.Factorial(0));
            Assert.AreEqual(1, Library.Recursion.Factorial(1));
            Assert.AreEqual(2, Library.Recursion.Factorial(2));
            Assert.AreEqual(6, Library.Recursion.Factorial(3));
        }
        [Test]
        public void MoreBasicTests()
        {
            var factorialTable = new ulong[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800, 479001600, 6227020800, 87178291200, 1307674368000 };

            factorialTable.Select((v, i) =>
            {
                Assert.AreEqual(v, Library.Recursion.Factorial((ulong)i));
                return 0;
            });
        }


        [Test]
        public void AntiCheatingTest()
        {
            // Until 20 the values are inside the ulong-range.
            Assert.AreEqual(2432902008176640000, Library.Recursion.Factorial(20));

            // So for 21 there must be an OverflowException, if the code is checked!
            Assert.Throws(typeof(OverflowException),
            delegate { Library.Recursion.Factorial(21); },
            "You have to leave the checked-Area in your code!");

            // from 20 to 24 are 4 Factorial-Calls -> Prove for Recursion!
            try
            {
                Library.Recursion.Factorial(24);
            }
            catch (OverflowException oex)
            {
                var stackTrace = new StackTrace(oex);

                var frameMethods = stackTrace.GetFrames().Select(st => st.GetMethod().Name);

                if (frameMethods.Count(fm => fm == "Factorial") != 4)
                {
                    Assert.Fail("You have to use Recursion!");
                }
            }
        }
    }
}
