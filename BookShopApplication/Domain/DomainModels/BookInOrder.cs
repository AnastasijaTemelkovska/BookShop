using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain.DomainModels
{
    public class BookInOrder : BaseEntity
    {
        public Guid BookId { get; set; }
        public Book SelectedBook { get; set; }
        public Guid OrderId { get; set; }
        public Order UserOrder { get; set; }
        public int Quantity { get; set; }


    }
}
