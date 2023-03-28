using System;
using InternetShop.Controllers;
using Npgsql;

namespace InternetShop
{
    public class DataReader
    {
        public static User ReadUser(NpgsqlDataReader reader)
        {
            int? actor_id = reader["actor_id"] as int?;
            string? first_name = reader["first_name"] as string;
            string? last_name = reader["last_name"] as string;

            User user = new User
            {
                ActorId = actor_id.Value,
                FirstName = first_name,
                LastName = last_name
            };
            return user;
        }
    }
}


