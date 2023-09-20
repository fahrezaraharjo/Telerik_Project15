using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class MenuItem
{
    public int MenuItemID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}

public class MenuItemsRepository
{
    private readonly string connectionString = "Server=DESKTOP-3D6BRA6;Database=PointOfSaleDB;Integrated Security=True;";

    public List<MenuItem> GetDataFromDatabase()
    {
        List<MenuItem> menuItems = new List<MenuItem>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT MenuItemID, Name, Description, Price FROM MenuItems";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        menuItems.Add(new MenuItem
                        {
                            MenuItemID = Convert.ToInt32(reader["MenuItemID"]),
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"])
                        });
                    }
                }
            }
        }

        return menuItems;
    }
}