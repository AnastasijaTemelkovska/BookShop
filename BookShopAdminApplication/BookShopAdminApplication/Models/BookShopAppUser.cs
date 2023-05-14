using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopAdminApplication.Models
{
    public class BookShopAppUser
    {
        public  string NormalizedEmail { get; set; }
        public  string Email { get; set; }
        public  string NormalizedUserName { get; set; }
        public  string UserName { get; set; }
    }
}
