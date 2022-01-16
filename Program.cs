﻿using System;
using BaltaDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BaltaDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            // const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$"; 
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;"; 
            
            // var connection = new SqlConnection();
            // connection.Open();
            
            // //INSERT
            // //UPDATE

            // connection.Close();
            // connection.Dispose();
            


            using(var connection = new SqlConnection(connectionString))
            {
                #region Método Antigo
                // Console.WriteLine("Conectado");
                // connection.Open();
                // using(var command = new SqlCommand()){
                //     command.Connection = connection;
                //     command.CommandType = System.Data.CommandType.Text;
                //     command.CommandText = "SELECT [ID], [Title]  FROM [Category]";

                //     var reader =  command.ExecuteReader();
                //     while(reader.Read()){
                //         Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
                //     }
                // }
                #endregion
                
              var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
              foreach(var category in categories){
                  Console.WriteLine($"{category.Id} - {category.Title}");
              }
            }

            Console.WriteLine("Hello World!");
        }
    }
}
