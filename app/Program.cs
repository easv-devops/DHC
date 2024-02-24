namespace app;

class Program
{
    static void Main(string[] args)
    {
       

        ICalculatorRepository repository = new CalculatorRepository(Utilities.ProperlyFormattedConnectionString);
        ICalculator calculator = new Calculator(repository);

        Console.WriteLine("Console Calculator\n");
        Console.WriteLine("Enter 'exit' to quit\n");

        while (true)
        {
            Console.Write("Enter first number: ");
            var input1 = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input1))
            {
                Console.WriteLine("No input detected. Try again.");
                continue;
            }
            if (input1.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
               break;

            if (!double.TryParse(input1, out var n1))
            {
                Console.WriteLine("Invalid number. Try again");
                continue;
            }

            Console.Write("Enter second number: ");
            var input2 = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input2))
            {
                Console.WriteLine("No input detected. Try again.");
                continue;
            }
            if (input2.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            if (!double.TryParse(input2, out var n2))
            {
                Console.WriteLine("Invalid number. Try again");
                continue;
            }

            Console.Write("Enter operation (add, subtract, multiply, divide): ");
            var operation = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(operation))
            {
                Console.WriteLine("No input detected. Try again.");
                continue;
            }
            if (operation.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            double result;

            switch (operation.Trim().ToLower())
            {
                case "add":
                    result = calculator.Add(n1, n2);
                    break;
                case "subtract":
                    result = calculator.Subtract(n1, n2);
                    break;
                case "multiply":
                    result = calculator.Multiply(n1, n2);
                    break;
                case "divide":
                    result = calculator.Divide(n1, n2);
                    break;
                default:
                    Console.WriteLine("Invalid operation. Try again");
                    continue;
            }

            Console.WriteLine($"Result: {result}\n");
        }

        Console.WriteLine("Goodbye!");
    }
}