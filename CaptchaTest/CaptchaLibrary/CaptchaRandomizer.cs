using System;
namespace CaptchaLibrary
{
    public class CaptchaRandomizer : ICaptchaRandomizer
    {
        public int GetPattern()
        {
            return new Random().Next(1, 3);
        }

        public int GetOperand()
        {
            return new Random().Next(1, 10);
        }

        public int GetOperator()
        {
            return new Random().Next(1, 4);
        }
    }
}
