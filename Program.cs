using System;
using System.Data.SqlClient;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("==== MENU ====");
                Console.WriteLine("(a) Se alla produkter i databaden");
                Console.WriteLine("(b) Se lager status för alla spelen");
                Console.WriteLine("(c) Se alla spel under kategorin action");
                Console.WriteLine("(d) Se alla spel under kategorin sport");
                Console.WriteLine("(e) Se alla spel under kategorin puzzle");
                Console.WriteLine("(f) Se alla spel under kategorin adveture");
                var val = Console.ReadLine().ToLower();

                if (val == "a" || val == "b" || val == "c" || val == "d" || val == "e" || val == "f")
                {
                    switch (val)
                    {
                        case "a":
                            Console.WriteLine("du valde A");
                            break;

                        case "b":
                            Console.WriteLine("du vale B");
                            break;

                        case "c":
                            Console.WriteLine("du valde C");
                            break;

                        case "d":
                            Console.WriteLine("du vale D");
                            break;

                        case "e":
                            Console.WriteLine("du valde E");
                            break;

                        case "f":
                            Console.WriteLine("du vale F");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Du måste ange ett val");
                }

            }


            //Skapar en connection string
            string connectionString = @"Data Source=mssql1.ilait.se;Initial Catalog=dbs126377;User Id=udmsbs459161;Password='=UW_,pV-n'";
          
            //Connectar till databasen
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Lyckad connection till DB");

                    //Skapa Mysql kod för att hämta info
                    string sql = "SELECT title, price FROM product";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string title = reader["title"].ToString();
                                decimal price = (decimal)reader["price"];

                                Console.WriteLine($"Title: {title}, Price: {price}");
                            }
                        }
                    }

                    //Sen får vi inte glömma att stänga connectionen
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Misslycklad connection till DB");
                }
            }
        }
    }
}