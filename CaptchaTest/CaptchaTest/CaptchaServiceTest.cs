using NSubstitute;
using NUnit.Framework;

namespace CaptchaTest
{
    using CaptchaLibrary;

    [TestFixture]
    public class LeftOperandShouldShownAsWordsIfPatternFormRandomReturn1
    {
        [Test]
        public void Captcha_ShouldBeONEPlus1_WhenPatternRandomizerReturn1()
        {
            var captchaService = new CaptchaService();
            var randomazock = Substitute.For<ICaptchaRandomizer>();
            randomazock.GetPattern().Returns(1);
            randomazock.GetOperand().Returns(1);
            randomazock.GetOperator().Returns(1);

            Assert.AreEqual("ONE+1", captchaService
                                        .GetCaptcha(randomazock.GetPattern(),
                                                    randomazock.GetOperand(),
                                                    randomazock.GetPattern(),
                                                    randomazock.GetOperand()).ToString());
        }

        [Test]
        public void Captcha_ShouldBeONEPlus2_WhenPatternRandomizerReturn1()
        {
            var captchaService = new CaptchaService();
            var randomizock = Substitute.For<ICaptchaRandomizer>();
            randomizock.GetPattern().Returns(1);
            randomizock.GetOperand().Returns(1);
            randomizock.GetOperator().Returns(1);

            var anotherRandomizock = Substitute.For<ICaptchaRandomizer>();
            anotherRandomizock.GetOperand().Returns(2);

            Assert.AreEqual("ONE+2", captchaService
                                        .GetCaptcha(randomizock.GetPattern(),
                                                    randomizock.GetOperand(),
                                                    randomizock.GetOperator(),
                                                    anotherRandomizock.GetOperand()).ToString());
        }

        [Test]
        public void Captcha_ShouldBeTWOPlus1_WhenPatternRandomizerReturn1()
        {
            var captchaService = new CaptchaService();
            var randomizock = Substitute.For<ICaptchaRandomizer>();
            randomizock.GetPattern().Returns(1);
            randomizock.GetOperand().Returns(2);
            randomizock.GetOperator().Returns(1);

            var anotherRandomizock = Substitute.For<ICaptchaRandomizer>();
            anotherRandomizock.GetOperand().Returns(1);

            Assert.AreEqual("TWO+1", captchaService
                                        .GetCaptcha(randomizock.GetPattern(),
                                                    randomizock.GetOperand(),
                                                    randomizock.GetOperator(),
                                                    anotherRandomizock.GetOperand()).ToString());
        }
    }

    public class RightOperandShouldShownAsWordsIfPatternFormRandomReturn2
    {
        [Test]
        public void Captcha_ShouldBe1PlusOne_WhenPatternRandomizerReturn2()
        {
            var captchaService = new CaptchaService();
            var randomazock = Substitute.For<ICaptchaRandomizer>();
            randomazock.GetPattern().Returns(2);
            randomazock.GetOperand().Returns(1);
            randomazock.GetOperator().Returns(1);

            Assert.AreEqual("1+ONE", captchaService
                                        .GetCaptcha(randomazock.GetPattern(),
                                                    randomazock.GetOperand(),
                                                    randomazock.GetOperator(),
                                                    randomazock.GetOperand()).ToString());
        }

        [Test]
        public void Captcha_ShouldBe2PlusONE_WhenPatternRandomizerReturn2()
        {
            var captchaService = new CaptchaService();
            var randomizock = Substitute.For<ICaptchaRandomizer>();
            randomizock.GetPattern().Returns(2);
            randomizock.GetOperand().Returns(1);
            randomizock.GetOperator().Returns(1);

            var anotherRandomizock = Substitute.For<ICaptchaRandomizer>();
            anotherRandomizock.GetOperand().Returns(2);

            Assert.AreEqual("2+ONE", captchaService
                                        .GetCaptcha(randomizock.GetPattern(),
                                                    anotherRandomizock.GetOperand(),
                                                    randomizock.GetOperator(),
                                                    randomizock.GetOperand()).ToString());
        }

        [Test]
        public void Captcha_ShouldBe1PlusTWO_WhenPatternRandomizerReturn2()
        {
            var captchaService = new CaptchaService();
            var randomizock = Substitute.For<ICaptchaRandomizer>();
            randomizock.GetPattern().Returns(2);
            randomizock.GetOperand().Returns(1);
            randomizock.GetOperator().Returns(1);

            var anotherRandomizock = Substitute.For<ICaptchaRandomizer>();
            anotherRandomizock.GetOperand().Returns(2);

            Assert.AreEqual("1+TWO", captchaService
                                        .GetCaptcha(randomizock.GetPattern(),
                                                    randomizock.GetOperand(),
                                                    randomizock.GetOperator(),
                                                    anotherRandomizock.GetOperand()).ToString());
        }
    }
}
