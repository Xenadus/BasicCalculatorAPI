namespace BasicCalculatorAPI.Services
{
    public interface ICalculator
    {
        double Calculate(string expression);
        string OperationType(string expression);
    }
}
