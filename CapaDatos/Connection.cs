using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Connection
    {
        static public SqlConnection getSqlConnection()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            return new SqlConnection(root.GetConnectionString("connection"));
        }

        static public void ExecuteQuery(string query, Action<SqlCommand> parameterSetup = null)
        {
            using (SqlConnection connection = getSqlConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        parameterSetup?.Invoke(cmd);
                    }
                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
