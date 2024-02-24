namespace app;


// Represents a calculator service that performs arithmetic operations using an underlying calculator.
public class CalculatorService
{
    private readonly ICalculator _calculator;
    
    public CalculatorService(ICalculator calculator)
    {
        _calculator = calculator;
    }

    // an instance of a calculator class `_calculator`, and returns the result as a double.
    public double PerformOperation(double n1, double n2, string operation)
    {
        switch (operation.Trim().ToLower())
        {
            case "add":
                return _calculator.Add(n1, n2);
            case "subtract":
                return _calculator.Subtract(n1, n2);
            case "multiply":
                return _calculator.Multiply(n1, n2);
            case "divide":
                return _calculator.Divide(n1, n2);
            default:
                throw new InvalidOperationException($"Invalid operation {operation}");
        }
    }
}