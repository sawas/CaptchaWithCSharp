using System;
namespace CaptchaLibrary
{
    public class CaptchaRandomizer : ICaptchaRandomizer
    {
        private static Random _r = new Random();

        public int GetPattern()
        {
            return _r.Next(1, 3);
        }

        public int GetOperand()
        {
            return _r.Next(1, 10);
        }

        public int GetOperator()
        {
            return _r.Next(1, 4);
        }
    }
}
