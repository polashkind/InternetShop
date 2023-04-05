using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
	public class UserModel
	{
        public int Id { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; } = null!;
        [MaxLength(20)]
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}

