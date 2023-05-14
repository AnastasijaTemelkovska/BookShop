
using BookShop.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain.DTO
{
    public class AddToShoppingCardDto
    {
        public Book SelectedBook { get; set; }
        public Guid BookId { get; set; }
        public int Quantity { get; set; }
    }
}
