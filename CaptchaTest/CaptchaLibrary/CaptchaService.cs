namespace CaptchaLibrary
{
    public class CaptchaService
    {
        public Captcha GetCaptcha(int pattern, int leftOperand, int operatorType, int rightOperand)
        {
            return new Captcha(pattern, leftOperand, operatorType, rightOperand);
        }
    }
}
