using BookShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public BookShopAppUser User { get; set; }

        public virtual ICollection<BookInOrder> Books { get; set; }
    }
}
