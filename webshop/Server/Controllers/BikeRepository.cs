using System;
using Microsoft.Data.Sqlite;
using webshop.Shared;

namespace webshop.Server.Controllers
{
    public class BikeRepository
    {
        public BikeRepository()
        {
        }

        public BEBike[] GetAll() {
            var result = new List<BEBike>();
            using (var connection = new SqliteConnection(@"Data Source=//Users/oleeriksen/Data/bikes.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM Bike";
             

                using (var reader = command.ExecuteReader())
                {
             
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        Console.WriteLine("Id=" + id);
                        var brand = reader.GetString(1);
                        var model = reader.GetString(2);
                        var desc = reader.GetString(3);
                        var price = reader.GetInt32(4);
                        var imgUrl = reader.GetString(5);

                        BEBike b = new BEBike { Brand = brand, Model = model, Description = desc, Price = price, ImageUrl = imgUrl };
                        result.Add(b);
                    }
                }
            }
            return result.ToArray();
        }
    }
}

