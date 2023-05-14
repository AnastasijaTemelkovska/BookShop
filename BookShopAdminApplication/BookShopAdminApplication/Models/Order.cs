using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopAdminApplication.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public BookShopAppUser User { get; set; }

        public  ICollection<BookInOrder> Books { get; set; }
    }
}
