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
    public class WhenCalculatingDistanceForTestWords : WhenTestingTheClass
    {
        protected int ReturnValue;

        protected override void When()
        {
            ReturnValue = ItemUnderTest.Distance("kitten", "sitting");
        }

        [Test]
        public void DistanceShouldBeThree()
        {
            Assert.That(ReturnValue, Is.EqualTo(3));
        }
    }
}
