using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using DAL.Context;
using DAL;
using DAL.Interfaces;

namespace InternetShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
	{
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        //[HttpGet(Name = "GetAll")]
        //public async Task<IActionResult> GetAll()
        //{
        //    var cs = "Host=localhost;port=3306;Username=postgres;Password=root;Database=dvdrental";
        //    using var connection = new NpgsqlConnection(cs);
        //    connection.Open();

        //    var sql = "SELECT * FROM actor";
        //    using var cmd = new NpgsqlCommand(sql, connection);

        //    using NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
        //    var userList = new List<User>();

        //    while (await reader.ReadAsync())
        //    {
        //        User user = DataReader.ReadUser(reader);
        //        userList.Add(user);
        //    }
        //    Console.WriteLine("UserList " + userList.Count());
        //    return Ok(userList);
        //}

        [HttpGet(Name = "GetAll")]
        public async Task<IEnumerable<UserEntity>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAll(cancellationToken);
            return result;

        }
    }
}