using NUnit.Framework;

namespace CaptchaTest
{
    using CaptchaLibrary;
    using NSubstitute;

    [TestFixture]
    public class RandomizerTest
    {
        private CaptchaRandomizer _randomizer = null;
        private const int _ITERATIONTIME = 100000;

        private const string _PATTERN = "PATTERN";
        private const string _OPERAND = "OPERAND";
        private const string _OPERATOR = "OPERATOR";

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
            Assert.AreEqual(true, RandomShouldbeExpectedValueAtLeastPercent(_PATTERN, 1, 40));
        }

        [Test]
        public void RandomValueOf_GetPattern_Shouldbe2AtLeast40Percent()
        {
            Assert.AreEqual(true, RandomShouldbeExpectedValueAtLeastPercent(_PATTERN, 2, 40));
        }

        [Test]
        public void RandomValueOf_GetOperand_ShouldbeInRangeOf1and9()
        {
            Assert.That(_randomizer.GetOperand(), Is.InRange(1, 9));
        }

        [Test]
        public void RandomValueOf_GetOperand_Shouldbe1AtLeast9Percent()
        {
            Assert.AreEqual(true, RandomShouldbeExpectedValueAtLeastPercent(_OPERAND, 1, 9));
        }

        [Test]
        public void RandomValueOf_GetOperand_Shouldbe5AtLeast9Percent()
        {
            Assert.AreEqual(true, RandomShouldbeExpectedValueAtLeastPercent(_OPERAND, 5, 9));
        }

        [Test]
        public void RandomValueOf_GetOperator_ShouldbeInRangeOf1and3()
        {
            Assert.That(_randomizer.GetOperator(), Is.InRange(1, 3));
        }

        [Test]
        public void RandomValueOf_GetOperator_Shouldbe1AtLeast30Percent()
        {
            Assert.AreEqual(true, RandomShouldbeExpectedValueAtLeastPercent(_OPERATOR, 1, 30));
        }

        [Test]
        public void RandomValueOf_GetOperator_Shouldbe2AtLeast30Percent()
        {
            Assert.AreEqual(true, RandomShouldbeExpectedValueAtLeastPercent(_OPERATOR, 2, 30));
        }

        [Test]
        public void RandomValueOf_GetOperator_Shouldbe3AtLeast30Percent()
        {
            Assert.AreEqual(true, RandomShouldbeExpectedValueAtLeastPercent(_OPERATOR, 3, 30));
        }

        private bool RandomShouldbeExpectedValueAtLeastPercent(string whatRandom, int expectedValue, int expectedPercent)
        {
            var counter = 0d;
            for (int i = 0; i < _ITERATIONTIME; i++)
            {
                var randomValue = 0;
                if (whatRandom == _PATTERN)
                {
                    randomValue = _randomizer.GetPattern();
                }
                else if (whatRandom == _OPERAND)
                {
                    randomValue = _randomizer.GetOperand();

                }
                else if (whatRandom == _OPERATOR)
                {
                    randomValue = _randomizer.GetOperator();
                }

                counter = ExpectedValueFoundIncrementor(expectedValue, counter, randomValue);
            }

            return (ExpectedValueFoundPercentage(_ITERATIONTIME, counter) >= expectedPercent);
        }

        private static double ExpectedValueFoundPercentage(int iterationTime, double counter)
        {
            return ((counter / iterationTime) * 100);
        }

        private static double ExpectedValueFoundIncrementor(int expectedValue, double counter, int randomValue)
        {
            if (randomValue == expectedValue)
            {
                counter++;
            }
            return counter;
        }
    }
}
