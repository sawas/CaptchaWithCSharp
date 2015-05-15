namespace CaptchaLibrary
{
    public interface ICaptchaRandomizer
    {
        int GetPattern();

        int GetOperand();

        int GetOperator();
    }
}
