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
    public class WhenFirstAndSecondAreIdentical : WhenTestingTheClass
    {
        protected MatchRatingResponse ReturnValue;

        protected override void When()
        {
            ReturnValue = ItemUnderTest.Rating("darren", "darren");
        }

        [Test]
        public void MatchRatingResponseShouldNotBeNull()
        {
            Assert.That(ReturnValue, Is.Not.Null);
        }

        [Test]
        public void CodexFirstShouldNotBeNull()
        {
            Assert.That(ReturnValue.CodexFirst, Is.Not.Null);
        }

        [Test]
        public void CodexFirstShouldNotBeEmpty()
        {
            Assert.That(ReturnValue.CodexFirst, Is.Not.Empty);
        }

        [Test]
        public void CodexSecondShouldNotBeNull()
        {
            Assert.That(ReturnValue.CodexSecond, Is.Not.Null);
        }

        [Test]
        public void CodexSecondShouldNotBeEmpty()
        {
            Assert.That(ReturnValue.CodexSecond, Is.Not.Empty);
        }

        [Test]
        public void CodexFirstIsCorrectForWord()
        {
            Assert.That(ReturnValue.CodexFirst, Is.EqualTo("DRN"));
        }
    }
}
