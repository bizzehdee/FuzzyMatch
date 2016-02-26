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
    public class WhenFirstIsEmpty : WhenTestingTheClass
    {
        protected int ReturnValue;

        protected override void When()
        {
            ReturnValue = ItemUnderTest.Distance(string.Empty, "aaa");
        }

        [Test]
        public void DistanceShouldBeZero()
        {
            Assert.That(ReturnValue, Is.EqualTo(0));
        }
    }
}
