using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
	public class UserEntity
	{
		public int Id { get; set; }
		[MaxLength(20)]
		public string FirstName { get; set; } = null!;
        [MaxLength(20)]
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}

