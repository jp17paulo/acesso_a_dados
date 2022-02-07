using System;
using BaltaDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BaltaDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Old
            // const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$"; 
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;"; 
            
            // var connection = new SqlConnection();
            // connection.Open();
            
            // //INSERT
            // //UPDATE

            // connection.Close();
            // connection.Dispose();

            // var category = new Category();
            // category.Id = Guid.NewGuid();
            // category.Title = "Amazon AWS";
            // category.Url = "amazon";
            // category.Description = "Categoria destinada a serviços do AWS";
            // category.Order = 8;
            // category.Summary = "AWS Cloud";
            // category.Featured = false;
            // var insertSql = @"INSERT INTO
            //         [Category] 
            // VALUES(
            //     @Id, 
            //     @Title, 
            //     @Url, 
            //     @Summary, 
            //     @Order, 
            //     @Description, 
            //     @Featured)";  

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

                // var rows = connection.Execute(insertSql, new {
                //     category.Id,
                //     category.Title,
                //     category.Url,
                //     category.Summary,
                //     category.Order,
                //     category.Description,
                //     category.Featured
                // }); 
                
                // Console.WriteLine($"{rows} linhas inseridas");

                // var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
                
                // foreach(var item in categories){
                //     Console.WriteLine($"{item.Id} - {item.Title}");
                //   }
                UpdateCategory(connection);
                ListCategories(connection);
                // CreateCategorie(connection);
                
                }

                Console.WriteLine("Hello World!");

            #endregion
            
        }
        
        static void ListCategories(SqlConnection connection){
             var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");

              foreach(var item in categories){
                    Console.WriteLine($"{item.Id} - {item.Title}");
                  }        
        }
    
        static void CreateCategorie(SqlConnection connection){
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

               var insertSql = @"INSERT INTO
                    [Category] 
            VALUES(
                @Id, 
                @Title, 
                @Url, 
                @Summary, 
                @Order, 
                @Description, 
                @Featured)";  

              var rows = connection.Execute(insertSql, new {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
               }); 
        }
    
        
        static void UpdateCategory(SqlConnection connection){
           
           var updateQuery = @"UPDATE 
                                 [Category]
                                SET
                                  [Title] = @title
                                WHERE
                                  [Id] = @id";

           var rows = connection.Execute(updateQuery, new {
               id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
               title = "Frontend 2022"
           });

           Console.WriteLine($"{rows} registros atualizados");

        }
    }
  }

