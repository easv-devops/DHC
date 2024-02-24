using Npgsql;

namespace app;

public interface ICalculatorRepository
{
    void LogCalculation(double n1, double n2, string operation, double result);
}


// CalculatorRepository class for logging calculations into a database.
public class CalculatorRepository : ICalculatorRepository
{
    
    // The connection string for connecting to a database.
    private readonly string _connectionString;

    // Creates a new instance of the CalculatorRepository class with the given connection string.
    public CalculatorRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Logs a calculation by inserting it into the 'calculator.calculations' table in the database.
    /// </summary>
    /// <param name="n1">The first number used in the calculation.</param>
    /// <param name="n2">The second number used in the calculation.</param>
    /// <param name="operation">The operation performed in the calculation.</param>
    /// <param name="result">The result of the calculation.</param>
    public void LogCalculation(double n1, double n2, string operation, double result)
    {
        using var con = new NpgsqlConnection(_connectionString);
        con.Open();

        using var cmd = new NpgsqlCommand("INSERT INTO calculator.calculations (n1, n2, operation, result) VALUES (@n1, @n2, @operation, @result)", con);

        cmd.Parameters.AddWithValue("n1", n1);
        cmd.Parameters.AddWithValue("n2", n2);
        cmd.Parameters.AddWithValue("operation", operation);
        cmd.Parameters.AddWithValue("result", result);

        cmd.ExecuteNonQuery();
    }
}