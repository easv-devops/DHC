namespace app;

public interface ICalculator
{
    double Add(double n1, double n2); 
    double Subtract(double n1, double n2); 
    double Multiply(double n1, double n2); 
    double Divide(double n1, double n2);
}


// Represents a calculator with basic arithmetic operations.
public class Calculator : ICalculator
{
    
    // Represents a calculator repository.
    private readonly ICalculatorRepository _repository;

    
    // Initializes a new instance of the Calculator class.
    public Calculator(ICalculatorRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Adds two numbers and logs the calculation.
    /// </summary>
    /// <param name="n1">The first number to be added.</param>
    /// <param name="n2">The second number to be added.</param>
    /// <returns>The sum of the two numbers.</returns>
    public double Add(double n1, double n2)
    {
        double result = n1 + n2;
        _repository.LogCalculation(n1, n2, "+", result);
        
        return result;
    }

    /// <summary>
    /// Subtracts two numbers.
    /// </summary>
    /// <param name="n1">The first number.</param>
    /// <param name="n2">The second number.</param>
    /// <returns>The result of subtracting <paramref name="n2"/> from <paramref name="n1"/>.</returns>
    public double Subtract(double n1, double n2)
    {
        double result = n1 - n2;
        _repository.LogCalculation(n1, n2, "-", result);
        
        return result;
    }

    /// <summary>
    /// Multiplies two numbers.
    /// </summary>
    /// <param name="n1">The first number to be multiplied.</param>
    /// <param name="n2">The second number to be multiplied.</param>
    /// <returns>The result of multiplying two numbers.</returns>
    public double Multiply(double n1, double n2)
    {
        double result = n1 * n2;
        _repository.LogCalculation(n1, n2, "*", result);
        
        return result;
    }

    /// <summary>
    /// Divides two numbers.
    /// </summary>
    /// <param name="n1">The dividend.</param>
    /// <param name="n2">The divisor.</param>
    /// <returns>The quotient of the division.</returns>
    /// <exception cref="DivideByZeroException">Thrown when the divisor is zero.</exception>
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