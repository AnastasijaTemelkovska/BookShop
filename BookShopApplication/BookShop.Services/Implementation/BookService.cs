
using BookShop.Domain.DomainModels;
using BookShop.Domain.DTO;
using BookShop.Repository.Interface;
using BookShop.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<BookInShoppingCart> _bookInShoppingCartRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<BookService> _logger;
        public BookService(IRepository<Book> bookRepository,
            IUserRepository userRepository,
            IRepository<BookInShoppingCart> bookInShoppingCartRepository,
            ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _bookInShoppingCartRepository = bookInShoppingCartRepository;
            _logger = logger;
        }
        public bool AddToShoppingCart(AddToShoppingCardDto item, string userID)
        {
            var user = this._userRepository.Get(userID);
            var userShoppingCard = user.UserCart;
            if (item.BookId != null && userShoppingCard != null)
            {
                var book = this.GetDetailsForBooks(item.BookId);

                if (book != null)
                {
                    BookInShoppingCart itemToAdd = new BookInShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        Book = book,
                        BookId = book.Id,
                        ShoppingCart = userShoppingCard,
                        ShoppingCartId = userShoppingCard.Id,
                        Quantity = item.Quantity
                    };
                    this._bookInShoppingCartRepository.Insert(itemToAdd);
                    _logger.LogInformation("Book was successfully added into ShoppingCart");
                    return true;
                }
                return false;

            }
            _logger.LogInformation("Something was wrong.  BookId or UserShoppingCard may be unaveliable");
            return false;
        }

        public void CreateNewBook(Book p)
        {
            this._bookRepository.Insert(p);
        }

        public void DeleteBook(Guid id)
        {
            var book = this.GetDetailsForBooks(id);
            this._bookRepository.Delete(book);
        }

        public List<Book> GetAllBooks()
        {
            _logger.LogInformation("GetALLBooks was called");
            return this._bookRepository.GetAll().ToList();

        }

        public Book GetDetailsForBooks(Guid? id)
        {
            return this._bookRepository.Get(id);
        }

        public AddToShoppingCardDto GetShoppingCartInfo(Guid? id)
        {
            var book = this.GetDetailsForBooks(id);
            AddToShoppingCardDto model = new AddToShoppingCardDto
            {
                SelectedBook = book,
                BookId = book.Id,
                Quantity = 1
            };
            return model;
        }

        public void UpdeteExistingBook(Book p)
        {
            this._bookRepository.Update(p);
        }
    }
}