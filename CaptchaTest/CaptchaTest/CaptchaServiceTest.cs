using NSubstitute;
using NUnit.Framework;

namespace CaptchaTest
{
    using CaptchaLibrary;

    [TestFixture]
    public class LeftOperandShouldShownAsWordsIfPatternFormRandomReturn1
    {
        private CaptchaService _captchaService = null;
        private ICaptchaRandomizer _randomizock = null;
        private ICaptchaRandomizer _anotherRandomizock = null;

        [SetUp]
        public void SetUp()
        {
            _captchaService = new CaptchaService();
            _randomizock = Substitute.For<ICaptchaRandomizer>();
            _anotherRandomizock = Substitute.For<ICaptchaRandomizer>();
        }

        [Test]
        public void Captcha_ShouldBeONEPlus1_WhenPatternRandomizerReturn1()
        {
            _randomizock.GetPattern().Returns(1);
            _randomizock.GetOperand().Returns(1);
            _randomizock.GetOperator().Returns(1);

            Assert.AreEqual("ONE+1", _captchaService
                                        .GetCaptcha(_randomizock.GetPattern(),
                                                    _randomizock.GetOperand(),
                                                    _randomizock.GetPattern(),
                                                    _randomizock.GetOperand()).ToString());
        }

        [Test]
        public void Captcha_ShouldBeONEPlus2_WhenPatternRandomizerReturn1()
        {
            _randomizock.GetPattern().Returns(1);
            _randomizock.GetOperand().Returns(1);
            _randomizock.GetOperator().Returns(1);
            _anotherRandomizock.GetOperand().Returns(2);

            Assert.AreEqual("ONE+2", _captchaService
                                        .GetCaptcha(_randomizock.GetPattern(),
                                                    _randomizock.GetOperand(),
                                                    _randomizock.GetOperator(),
                                                    _anotherRandomizock.GetOperand()).ToString());
        }

        [Test]
        public void Captcha_ShouldBeTWOPlus1_WhenPatternRandomizerReturn1()
        {
            _randomizock.GetPattern().Returns(1);
            _randomizock.GetOperand().Returns(2);
            _randomizock.GetOperator().Returns(1);
            _anotherRandomizock.GetOperand().Returns(1);

            Assert.AreEqual("TWO+1", _captchaService
                                        .GetCaptcha(_randomizock.GetPattern(),
                                                    _randomizock.GetOperand(),
                                                    _randomizock.GetOperator(),
                                                    _anotherRandomizock.GetOperand()).ToString());
        }
    }

    [TestFixture]
    public class RightOperandShouldShownAsWordsIfPatternFormRandomReturn2
    {
        private CaptchaService _captchaService = null;
        private ICaptchaRandomizer _randomizock = null;
        private ICaptchaRandomizer _anotherRandomizock = null;

        [SetUp]
        public void SetUp()
        {
            _captchaService = new CaptchaService();
            _randomizock = Substitute.For<ICaptchaRandomizer>();
            _anotherRandomizock = Substitute.For<ICaptchaRandomizer>();
        }

        [Test]
        public void Captcha_ShouldBe1PlusOne_WhenPatternRandomizerReturn2()
        {
            _randomizock.GetPattern().Returns(2);
            _randomizock.GetOperand().Returns(1);
            _randomizock.GetOperator().Returns(1);

            Assert.AreEqual("1+ONE", _captchaService
                                        .GetCaptcha(_randomizock.GetPattern(),
                                                    _randomizock.GetOperand(),
                                                    _randomizock.GetOperator(),
                                                    _randomizock.GetOperand()).ToString());
        }

        [Test]
        public void Captcha_ShouldBe2PlusONE_WhenPatternRandomizerReturn2()
        {
            _randomizock.GetPattern().Returns(2);
            _anotherRandomizock.GetOperand().Returns(2);
            _randomizock.GetOperator().Returns(1);
            _randomizock.GetOperand().Returns(1);

            Assert.AreEqual("2+ONE", _captchaService
                                        .GetCaptcha(_randomizock.GetPattern(),
                                                    _anotherRandomizock.GetOperand(),
                                                    _randomizock.GetOperator(),
                                                    _randomizock.GetOperand()).ToString());
        }

        [Test]
        public void Captcha_ShouldBe1PlusTWO_WhenPatternRandomizerReturn2()
        {
            _randomizock.GetPattern().Returns(2);
            _randomizock.GetOperand().Returns(1);
            _randomizock.GetOperator().Returns(1);

            _anotherRandomizock.GetOperand().Returns(2);

            Assert.AreEqual("1+TWO", _captchaService
                                        .GetCaptcha(_randomizock.GetPattern(),
                                                    _randomizock.GetOperand(),
                                                    _randomizock.GetOperator(),
                                                    _anotherRandomizock.GetOperand()).ToString());
        }
    }

    [TestFixture]
    public class InvalidRangExceptionShouldbeThrownIfPatternAndOperandRandomizerReturnAnInvalidRangeValue
    {
        private CaptchaService _captchaService = null;
        private ICaptchaRandomizer _randomizock = null;

        [SetUp]
        public void SetUp()
        {
            _captchaService = new CaptchaService();
            _randomizock = Substitute.For<ICaptchaRandomizer>();
        }

        [Test]
        public void Captcha_ShouldBeThrownInvalidRangeException_IfRandomPatternIsInvalidMinValue()
        {
            _randomizock.GetPattern().Returns(0);
            _randomizock.GetOperand().Returns(1);
            _randomizock.GetOperator().Returns(1);

            Assert.Throws(typeof(InvalidRangeException),
                delegate
                {
                    _captchaService.GetCaptcha(_randomizock.GetPattern(),
                                             _randomizock.GetOperand(),
                                             _randomizock.GetOperator(),
                                             _randomizock.GetOperand()).ToString();
                });
        }

        [Test]
        public void Captcha_ShouldBeThrownInvalidRangeException_IfRandomPatternIsInvalidMaxValue()
        {
            _randomizock.GetPattern().Returns(3);
            _randomizock.GetOperand().Returns(1);
            _randomizock.GetOperator().Returns(1);

            Assert.Throws(typeof(InvalidRangeException),
                delegate
                {
                    _captchaService.GetCaptcha(_randomizock.GetPattern(),
                                             _randomizock.GetOperand(),
                                             _randomizock.GetOperator(),
                                             _randomizock.GetOperand()).ToString();
                });
        }

        [Test]
        public void Captcha_ShouldBeThrownInvalidRangeException_IfRandomOperandIsInvalidMinValue()
        {
            _randomizock.GetPattern().Returns(1);
            _randomizock.GetOperand().Returns(0);
            _randomizock.GetOperator().Returns(1);

            Assert.Throws(typeof(InvalidRangeException),
                delegate
                {
                    _captchaService.GetCaptcha(_randomizock.GetPattern(),
                                             _randomizock.GetOperand(),
                                             _randomizock.GetOperator(),
                                             _randomizock.GetOperand()).ToString();
                });
        }

        [Test]
        public void Captcha_ShouldBeThrownInvalidRangeException_IfRandomOperandIsInvalidMaxValue()
        {
            _randomizock.GetPattern().Returns(1);
            _randomizock.GetOperand().Returns(99);
            _randomizock.GetOperator().Returns(1);

            Assert.Throws(typeof(InvalidRangeException),
                delegate
                {
                    _captchaService.GetCaptcha(_randomizock.GetPattern(),
                                             _randomizock.GetOperand(),
                                             _randomizock.GetOperator(),
                                             _randomizock.GetOperand()).ToString();
                });
        }
    }

    [TestFixture]
    public class InvalidOperatorExceptionShouldbeThrownIfOperatorRandomizerReturnAnInvalidRangeValue
    {
        private CaptchaService _captchaService = null;
        private ICaptchaRandomizer _randomizock = null;

        [SetUp]
        public void SetUp()
        {
            _captchaService = new CaptchaService();
            _randomizock = Substitute.For<ICaptchaRandomizer>();
        }

        [Test]
        public void Captcha_ShouldBeThrownInvalidFormatOperatorException_IfRandomOperatorIsInvalidMinValue()
        {
            _randomizock.GetPattern().Returns(1);
            _randomizock.GetOperand().Returns(1);
            _randomizock.GetOperator().Returns(0);

            Assert.Throws(typeof(InvalidFormatOperatorException),
                delegate
                {
                    _captchaService.GetCaptcha(_randomizock.GetPattern(),
                                             _randomizock.GetOperand(),
                                             _randomizock.GetOperator(),
                                             _randomizock.GetOperand()).ToString();
                });
        }

        [Test]
        public void Captcha_ShouldBeThrownInvalidFormatOperatorException_IfRandomOperatorIsInvalidMaxValue()
        {
            _randomizock.GetPattern().Returns(1);
            _randomizock.GetOperand().Returns(1);
            _randomizock.GetOperator().Returns(99);

            Assert.Throws(typeof(InvalidFormatOperatorException),
                delegate
                {
                    _captchaService.GetCaptcha(_randomizock.GetPattern(),
                                             _randomizock.GetOperand(),
                                             _randomizock.GetOperator(),
                                             _randomizock.GetOperand()).ToString();
                });
        }
    }
}
