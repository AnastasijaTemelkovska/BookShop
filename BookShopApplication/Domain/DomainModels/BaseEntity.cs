using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Domain.DomainModels
{
    public class BaseEntity
    {
        
        public Guid Id { get; set; }
    }
}
