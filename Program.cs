using System;
using System.Data.SqlClient;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== MENU ====");

            //Skapar en connection string
            string connectionString = @"Data Source=mssql1.ilait.se;Initial Catalog=dbs126377;User Id=udmsbs459161;Password='=UW_,pV-n'";
          
            //Connectar till databasen
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Database connection successful!");

                    //Här skriver vi vad vi vill testa

                    //Sen får vi inte glömma att stänga connectionen
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error connecting to database: " + ex.Message);
                }
            }
        }
    }
}