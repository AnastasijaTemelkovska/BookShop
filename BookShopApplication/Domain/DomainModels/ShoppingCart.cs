
using BookShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {

        public string OwnerId { get; set; }
        public virtual BookShopAppUser Owner { get; set; }
        public virtual ICollection<BookInShoppingCart> BookInShoppingCarts { get; set; }

    }
}
