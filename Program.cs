using Microsoft.Data.SqlClient;

namespace docker_compose_example;

class Program
{
    static void Main(string[] args)
    {
        CreateDatabase();
    }

    private static void CreateDatabase()
    {
        const string connectionString = "Server=localhost,1433;User ID=sa;Password=YourStrong!Passw0rd;Encrypt=True;TrustServerCertificate=True";

        try
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                const string sql = @"
                    IF DB_ID('NewDatabase') IS NULL
                    BEGIN
                        CREATE DATABASE [NewDatabase];
                    END";

                using var cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                Console.WriteLine($"Database Created!.");
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Error occured");
            Console.WriteLine(ex.Message);
        }

    }
}
