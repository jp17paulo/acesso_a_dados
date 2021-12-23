using System;
using Microsoft.Data.SqlClient;

namespace BaltaDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$";  
            
            // var connection = new SqlConnection();
            // connection.Open();
            
            // //INSERT
            // //UPDATE

            // connection.Close();
            // connection.Dispose();
            
            using(var connection = new SqlConnection())
            {
                Console.WriteLine("Conectado");
            }

            Console.WriteLine("Hello World!");
        }
    }
}
