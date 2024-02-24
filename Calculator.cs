namespace Calculator;

public interface ICalculator
{
    double Add(double n1, double n2); 
    double Subtract(double n1, double n2); 
    double Multiply(double n1, double n2); 
    double Divide(double n1, double n2);
}
public class Calculator : ICalculator
{
    private readonly ICalculatorRepository _repository;

    public Calculator(ICalculatorRepository repository)
    {
        _repository = repository;
    }

    public double Add(double n1, double n2)
    {
        double result = n1 + n2;
        _repository.LogCalculation(n1, n2, "+", result);
        
        return result;
    }

    public double Subtract(double n1, double n2)
    {
        double result = n1 - n2;
        _repository.LogCalculation(n1, n2, "-", result);
        
        return result;
    }

    public double Multiply(double n1, double n2)
    {
        double result = n1 * n2;
        _repository.LogCalculation(n1, n2, "*", result);
        
        return result;
    }
    
    public double Divide(double n1, double n2)
    {
        if(n2 == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }
        
        double result = n1 / n2;
        _repository.LogCalculation(n1, n2, "/", result);
        
        return result;
    }
}