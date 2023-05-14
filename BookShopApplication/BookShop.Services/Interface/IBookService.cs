using BookShop.Domain.DomainModels;
using BookShop.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Services.Interface
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetDetailsForBooks(Guid? id);
        void CreateNewBook(Book p);
        void UpdeteExistingBook(Book p);
        AddToShoppingCardDto GetShoppingCartInfo(Guid? id);
        void DeleteBook(Guid id);
        bool AddToShoppingCart(AddToShoppingCardDto item, string userID);
    }
}

