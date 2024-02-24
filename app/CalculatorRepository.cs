using Npgsql;

namespace app;

public interface ICalculatorRepository
{
    void LogCalculation(double n1, double n2, string operation, double result);
}

public class CalculatorRepository : ICalculatorRepository
{
    private readonly string _connectionString;

    public CalculatorRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

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