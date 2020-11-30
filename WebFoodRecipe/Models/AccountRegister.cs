using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFoodRecipe.Models
{
    public class AccountRegister
    {
        private string name;
        private string email;
        private string password;
        private string confirm_password;
        private string image;

        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Confirm_password { get => confirm_password; set => confirm_password = value; }
        public string Image { get => image; set => image = value; }
    }
}