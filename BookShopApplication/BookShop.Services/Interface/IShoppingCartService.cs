using BookShop.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Services.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto getShoppingCartInfo(string userId);
        bool deleteBookFromSoppingCart(string userId, Guid id);
        bool orderNow(string userId);
    }
}
