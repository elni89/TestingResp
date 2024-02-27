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

                            //quantity, category, platform, description, releaseDate, imageURL, downloadURL

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