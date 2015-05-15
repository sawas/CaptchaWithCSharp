using NUnit.Framework;

namespace CaptchaTest
{
    using CaptchaLibrary;
    using NSubstitute;

    [TestFixture]
    public class RandomizerTest
    {
        private CaptchaRandomizer _randomizer = null;
        private static int _iterationTime = 100000;

        [SetUp]
        public void SetUp()
        {
            _randomizer = new CaptchaRandomizer();
        }

        [Test]
        public void RandomValueOf_GetPattern_ShouldbeInRangeOf1and2()
        {
            Assert.That(_randomizer.GetPattern(), Is.InRange(1, 2));
        }

        [Test]
        public void RandomValueOf_GetPattern_Shouldbe1AtLeast40Percent()
        {
            Assert.AreEqual(true, RandomPatternShouldbeExpectedValueAtLeastPercent(1, _iterationTime, 40));
        }

        [Test]
        public void RandomValueOf_GetPattern_Shouldbe2AtLeast40Percent()
        {
            Assert.AreEqual(true, RandomPatternShouldbeExpectedValueAtLeastPercent(2, _iterationTime, 40));
        }

        [Test]
        public void RandomValueOf_GetOperand_ShouldbeInRangeOf1and9()
        {
            Assert.That(_randomizer.GetOperand(), Is.InRange(1, 9));
        }

        [Test]
        public void RandomValueOf_GetOperand_Shouldbe1AtLeast9Percent()
        {
            Assert.AreEqual(true, RandomOperrandShouldbeExpectedValueAtLeastPercent(1, _iterationTime, 9));
        }

        [Test]
        public void RandomValueOf_GetOperand_Shouldbe5AtLeast9Percent()
        {
            Assert.AreEqual(true, RandomOperrandShouldbeExpectedValueAtLeastPercent(5, _iterationTime, 9));
        }

        [Test]
        public void RandomValueOf_GetOperator_ShouldbeInRangeOf1and3()
        {
            Assert.That(_randomizer.GetOperator(), Is.InRange(1, 3));
        }

        [Test]
        public void RandomValueOf_GetOperator_Shouldbe1AtLeast30Percent()
        {
            Assert.AreEqual(true, RandomOperatorShouldbeExpectedValueAtLeastPercent(1, _iterationTime, 30));
        }

        [Test]
        public void RandomValueOf_GetOperator_Shouldbe2AtLeast30Percent()
        {
            Assert.AreEqual(true, RandomOperatorShouldbeExpectedValueAtLeastPercent(2, _iterationTime, 30));
        }

        [Test]
        public void RandomValueOf_GetOperator_Shouldbe3AtLeast30Percent()
        {
            Assert.AreEqual(true, RandomOperatorShouldbeExpectedValueAtLeastPercent(3, _iterationTime, 30));
        }

        private bool RandomPatternShouldbeExpectedValueAtLeastPercent(int expectedValue,
            int iterationTime, int expectedPercent)
        {
            var counter = 0d;
            for (int i = 0; i < iterationTime; i++)
            {
                if (_randomizer.GetPattern() == expectedValue)
                {
                    counter++;
                }
            }

            return (((counter / iterationTime) * 100) >= expectedPercent);
        }

        private object RandomOperrandShouldbeExpectedValueAtLeastPercent(int expectedValue,
            int iterationTime, int expectedPercent)
        {
            var counter = 0d;
            for (int i = 0; i < iterationTime; i++)
            {
                if (_randomizer.GetOperand() == expectedValue)
                {
                    counter++;
                }
            }

            return (((counter / iterationTime) * 100) >= expectedPercent);
        }

        private bool RandomOperatorShouldbeExpectedValueAtLeastPercent(int expectedValue,
            int iterationTime, int expectedPercent)
        {
            var counter = 0d;
            for (int i = 0; i < iterationTime; i++)
            {
                if (_randomizer.GetOperator() == expectedValue)
                {
                    counter++;
                }
            }

            return (((counter / iterationTime) * 100) >= expectedPercent);
        }
    }
}
