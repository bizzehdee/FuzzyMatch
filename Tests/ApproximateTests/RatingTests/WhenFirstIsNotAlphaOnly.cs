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
    public class WhenFirstIsNotAlphaOnly : WhenTestingTheClass
    {
        protected bool ThrewException;

        protected override void When()
        {
            try
            {
                ItemUnderTest.Rating("a-a-a-a", "aaa");
            }
            catch (ArgumentException)
            {
                ThrewException = true;
            }
        }

        [Test]
        public void ShouldThrowAnArgumentException()
        {
            Assert.That(ThrewException, Is.True);
        }
    }
}
