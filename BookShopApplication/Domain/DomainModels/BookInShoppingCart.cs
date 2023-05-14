using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain.DomainModels
{
    public class BookInShoppingCart : BaseEntity
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int Quantity { get; set; }


    }
}
