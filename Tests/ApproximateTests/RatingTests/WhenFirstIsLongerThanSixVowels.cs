using FuzzyMatch;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ApproximateTests.RatingTests
{
    [TestFixture]
    [Category("Approximate")]
    public class WhenFirstIsLongerThanSixVowels : WhenTestingTheClass
    {
        protected MatchRatingResponse ReturnValue;

        protected override void When()
        {
            ReturnValue = ItemUnderTest.Rating("Approximation", "Approximation");
        }

        [Test]
        public void ShouldHaveCodexLengthSix()
        {
            Assert.That(ReturnValue.CodexFirst.Length, Is.EqualTo(6));
        }
    }
}
