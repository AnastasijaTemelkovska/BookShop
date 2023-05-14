using BookShop.Domain.DomainModels;
using BookShop.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        string errorMessage = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        public List<Order> GetAllOrders()
        {
            return entities
                .Include(z=>z.Books)
                .Include(z=>z.User)
                .Include("Books.SelectedBook")
                .ToListAsync().Result;
        }

        public Order GetOrderDetails(BaseEntity model)
        {
            return entities
                 .Include(z => z.Books)
                 .Include(z => z.User)
                 .Include("Books.SelectedBook")
                 .SingleOrDefaultAsync(z=>z.Id == model.Id).Result;
        }
    }
}
