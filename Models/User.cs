using System.Collections.Generic;

namespace StockPro.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Image { get; set; }

        //public IList<Role> Roles { get; set; }
    }
}