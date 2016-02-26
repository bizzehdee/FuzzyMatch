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
    public class WhenUsingTestWordsOne : WhenTestingTheClass
    {
        protected MatchRatingResponse ReturnValue;

        protected override void When()
        {
            ReturnValue = ItemUnderTest.Rating("Byrne", "Boern");
        }

        [Test]
        public void MinimumRatingShouldBeFour()
        {
            Assert.That(ReturnValue.MinimumRating, Is.EqualTo(4));
        }

        [Test]
        public void ActualRatingShouldBeFive()
        {
            Assert.That(ReturnValue.ActualRating, Is.EqualTo(5));
        }

        [Test]
        public void CodexFirstShouldBeCorrect()
        {
            Assert.That(ReturnValue.CodexFirst, Is.EqualTo("BYRN"));
        }

        [Test]
        public void CodexSecondShouldBeCorrect()
        {
            Assert.That(ReturnValue.CodexSecond, Is.EqualTo("BRN"));
        }
    }
}
