using System;
using System.Data.SqlClient;

public class DatabaseManagerAllQuantity
{
    public void quantity()
    {
        string connectionString = @"Data Source=mssql1.ilait.se;Initial Catalog=dbs126377;User Id=udmsbs459161;Password='=UW_,pV-n'";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                string sql = "SELECT title, quantity FROM product"; // Corrected table name

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader["title"].ToString();
                            int quantity = (int)reader["quantity"];

                            Console.WriteLine($"Title: {title}");
                            Console.WriteLine($"Quantity: {quantity}");
                            Console.WriteLine("============================================");
                            Console.WriteLine();
                        }
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to connect to the database: " + ex.Message);
            }
        }
    }
}