using System.ComponentModel.DataAnnotations;

namespace InternetShop.ViewModels.UserViewModels
{
	public class ChangeUserViewModel
	{
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}

