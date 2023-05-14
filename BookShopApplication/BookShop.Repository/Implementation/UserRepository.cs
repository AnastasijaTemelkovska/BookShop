using BookShop.Domain.Identity;
using BookShop.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext context;
        private DbSet<BookShopAppUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<BookShopAppUser>();
        }
        public IEnumerable<BookShopAppUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public BookShopAppUser Get(string id)
        {
            return entities
                .Include(z => z.UserCart)
                .Include("UserCart.BookInShoppingCarts")
                .Include("UserCart.BookInShoppingCarts.Book")
                .SingleOrDefault(s => s.Id == id);
        }
        public void Insert(BookShopAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(BookShopAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(BookShopAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
