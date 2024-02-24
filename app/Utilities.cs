namespace app;

// This class is used to structure the connection string, based on a string from elephantSql
public class Utilities
{
    
    private static readonly Uri Uri = new Uri(Environment.GetEnvironmentVariable("pgconn")!);

    public static readonly string
        ProperlyFormattedConnectionString = string.Format(
            "Server={0};Database={1};User Id={2};Password={3};Port={4};Pooling=true;MaxPoolSize=5;",
            Uri.Host,
            Uri.AbsolutePath.Trim('/'),
            Uri.UserInfo.Split(':')[0],
            Uri.UserInfo.Split(':')[1],
            Uri.Port > 0 ? Uri.Port : 5432);
    
}