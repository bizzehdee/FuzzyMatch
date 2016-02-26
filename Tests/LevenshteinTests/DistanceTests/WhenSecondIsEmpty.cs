using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.LevenshteinTests.DistanceTests
{
    [TestFixture]
    [Category("Levenshtein")]
    public class WhenSecondIsEmpty : WhenTestingTheClass
    {
        protected int ReturnValue;

        protected override void When()
        {
            ReturnValue = ItemUnderTest.Distance("aaa", string.Empty);
        }

        [Test]
        public void DistanceShouldBeZero()
        {
            Assert.That(ReturnValue, Is.EqualTo(0));
        }
    }
}
