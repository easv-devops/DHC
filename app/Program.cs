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

    
    // This method runs a console calculator program.
    // It prompts the user to enter two numbers and an operation, and then performs the operation and displays the result.
    // The program continues running until the user enters 'exit' or encounters an error.
    public void Run()
    {
        Console.WriteLine("Console Calculator\n");
        Console.WriteLine("Enter 'exit' to quit\n");

        while (true)
        {
            double n1 = GetNumber("Enter first number: ");
            if (double.IsNaN(n1)) break;

            double n2 = GetNumber("Enter second number: ");
            if (double.IsNaN(n2)) break;

            string operation = GetOperation();
            if (operation == null) break;

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
        }

        Console.WriteLine("Goodbye!");
    }

    
    // Prompts the user to enter a number and returns the entered number.
    // Returns the entered number. Returns NaN if the user enters a blank or "exit" as the input.
    // Returns NaN if the user enters an invalid number.
    private double GetNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) || input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                return double.NaN;
            }

            if (double.TryParse(input, out var number))
            {
                return number;
            }

            Console.WriteLine("Invalid number. Try again");
        }
    }

    
    // Prompts the user to enter an operation (add, subtract, multiply, divide) and returns the entered operation.
    // Returns the entered operation.
    private string GetOperation()
    {
        while (true)
        {
            Console.Write("Enter operation (add, subtract, multiply, divide): ");
            var operation = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(operation) || operation.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            return operation;
        }
    }

    
    // The entry point of the application.
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }
}