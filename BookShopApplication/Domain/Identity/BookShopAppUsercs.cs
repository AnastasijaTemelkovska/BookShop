
using BookShop.Domain.DomainModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain.Identity
{
    public class BookShopAppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        //onetoone relacija
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ShoppingCart UserCart { get; set; }
    }
}
