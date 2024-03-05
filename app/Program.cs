namespace app;

public class Program
{
    // Represents a calculator service object.
    // This object provides functionality for performing basic mathematical operations.
    private readonly CalculatorService _calculatorService;

    public Program()
    {
        ICalculatorRepository repository = new CalculatorRepository(Utilities.ProperlyFormattedConnectionString);
        ICalculator calculator = new Calculator(repository);
        _calculatorService = new CalculatorService(calculator);
    }

    // This method runs a calculator program.
    // It uses preset numbers and operation, performs the operation and displays the result.
    public void Run()
    {
        Console.WriteLine("Calculator\n");

        double n1 = 25;
        double n2 = 5;
        string operation = "divide";

        double result;

        try
        {
            result = _calculatorService.PerformOperation(n1, n2, operation);
            Console.WriteLine($"Result: {result}\n");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Goodbye!");
    }

    // The entry point of the application.
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }
}