using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Collections.Generic;
using InternetShop.Controllers;

namespace InternetShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
	{
        [HttpGet(Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var cs = "Host=localhost;port=3306;Username=postgres;Password=root;Database=dvdrental";
            using var connection = new NpgsqlConnection(cs);
            connection.Open();

            string sql = "SELECT * FROM actor";
            using var cmd = new NpgsqlCommand(sql, connection);

            using NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            List<User> UserList = new List<User>();

            while (await reader.ReadAsync())
            {
                //Console.WriteLine("{0} {1} {2}", rdr.GetInt16(0), rdr.GetString(1),
                //        rdr.GetString(2));
                User user = DataReader.ReadUser(reader);
                UserList.Add(user);
            }
            Console.WriteLine("UserList " + UserList.Count());
            return Ok(UserList);
        }
    }
}