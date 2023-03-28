using Microsoft.AspNetCore.Mvc;
using Npgsql;

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

            var sql = "SELECT * FROM actor";
            using var cmd = new NpgsqlCommand(sql, connection);

            using NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            var userList = new List<User>();

            while (await reader.ReadAsync())
            {
                User user = DataReader.ReadUser(reader);
                userList.Add(user);
            }
            Console.WriteLine("UserList " + userList.Count());
            return Ok(userList);
        }
    }
}