using BookShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<BookShopAppUser> GetAll();
        BookShopAppUser Get(string id);
        void Insert(BookShopAppUser entity);
        void Update(BookShopAppUser entity);
        void Delete(BookShopAppUser entity);
    }
}
