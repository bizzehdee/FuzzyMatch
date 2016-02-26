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
    public class WhenUsingTestWordsThree : WhenTestingTheClass
    {
        protected MatchRatingResponse ReturnValue;

        protected override void When()
        {
            ReturnValue = ItemUnderTest.Rating("Catherine", "Kathryn");
        }

        [Test]
        public void MinimumRatingShouldBeThree()
        {
            Assert.That(ReturnValue.MinimumRating, Is.EqualTo(3));
        }

        [Test]
        public void ActualRatingShouldBeFour()
        {
            Assert.That(ReturnValue.ActualRating, Is.EqualTo(4));
        }

        [Test]
        public void CodexFirstShouldBeCorrect()
        {
            Assert.That(ReturnValue.CodexFirst, Is.EqualTo("CTHRN"));
        }

        [Test]
        public void CodexSecondShouldBeCorrect()
        {
            Assert.That(ReturnValue.CodexSecond, Is.EqualTo("KTHRYN"));
        }
    }
}
