using System;
using System.Data.SqlClient;


public class DatabaseManager
{
    public void Sayhello()
    {
        //Skapar en connection string
        string connectionString = @"Data Source=mssql1.ilait.se;Initial Catalog=dbs126377;User Id=udmsbs459161;Password='=UW_,pV-n'";

        //Connectar till databasen
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                //öppnar connection till databasen
                connection.Open();

                //Skapa MYSQL kod för att hämta info
                string sql = "SELECT title, price, quantity, category, platform, description, releaseDate, imageURL, downloadURL FROM product";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader["title"].ToString();
                            decimal price = (decimal)reader["price"];
                            int quantity = (int)reader["quantity"];
                            string category = reader["category"].ToString();
                            string platform = reader["platform"].ToString();
                            string description = reader["description"].ToString();
                            DateTime releaseDate = (DateTime)reader["releaseDate"];
                            string imageURL = reader["imageURL"].ToString();
                            string downloadURL = reader["downloadURL"].ToString();

                            // Display game information on separate lines
                            Console.WriteLine($"Title: {title}");
                            Console.WriteLine($"Price: {price}");
                            Console.WriteLine($"Quantity: {quantity}");
                            Console.WriteLine($"Category: {category}");
                            Console.WriteLine($"Platform: {platform}");
                            Console.WriteLine($"Description: {description}");
                            Console.WriteLine($"Release Date: {releaseDate}");
                            Console.WriteLine($"Image URL: {imageURL}");
                            Console.WriteLine($"Download URL: {downloadURL}");
                            Console.WriteLine("============================================");
                            Console.WriteLine(); // Add a blank line for spacing
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