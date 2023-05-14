using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopAdminApplication.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string BookName { get; set; }

        public string Author { get; set; }

        public string BookImage { get; set; }

        public string BookDescription { get; set; }
 
        public int BookPrice { get; set; }

        public int Rating { get; set; }
       

    }
}
