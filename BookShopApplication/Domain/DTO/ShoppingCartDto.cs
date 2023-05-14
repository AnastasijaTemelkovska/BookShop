
using BookShop.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<BookInShoppingCart> Books { get; set; }

        public double TotalPrice { get; set; }
    }
}
