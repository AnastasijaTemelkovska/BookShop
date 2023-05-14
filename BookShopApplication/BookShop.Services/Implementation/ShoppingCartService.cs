using BookShop.Domain.DomainModels;
using BookShop.Domain.DTO;
using BookShop.Repository.Interface;
using BookShop.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Services.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {

        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<EmailMessage> _mailRepository;
        private readonly IRepository<BookInOrder> _bookInOrderRepository;
        private readonly IUserRepository _userRepository;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository,
                                  IRepository<Order> orderRepository,
                                  IRepository<EmailMessage> mailRepository,
                                   IRepository<BookInOrder> bookInOrderRepository,
                                   IUserRepository userRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _orderRepository = orderRepository;
            _mailRepository = mailRepository;
            _bookInOrderRepository = bookInOrderRepository;
            _userRepository = userRepository;

        }

        public bool deleteBookFromSoppingCart(string userId, Guid id)
        {
           

            if (!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                var bookToDelete = userShoppingCart.BookInShoppingCarts
                    .Where(z => z.BookId.Equals(id)).FirstOrDefault();

                userShoppingCart.BookInShoppingCarts.Remove(bookToDelete);

                this._shoppingCartRepository.Update(userShoppingCart);
                return true;
            }
            return false;


        }

        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            var loggerdInUser = this._userRepository.Get(userId);

            var userShoppingCart = loggerdInUser.UserCart;
            var bookPrice = userShoppingCart.BookInShoppingCarts.Select(z => new
            {
                BookPrice = z.Book.BookPrice,
                Quantity = z.Quantity
            }).ToList();

            double totalPrice = 0;
            foreach (var item in bookPrice)
            {
                totalPrice += item.BookPrice * item.Quantity;
            }
            ShoppingCartDto shoppingCartDtoItem = new ShoppingCartDto
            {
                Books = userShoppingCart.BookInShoppingCarts.ToList(),
                TotalPrice = totalPrice
            };
            return shoppingCartDtoItem;
        }

        public bool orderNow(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingcart = loggedInUser.UserCart;
                EmailMessage message = new EmailMessage();
                message.MailTo = loggedInUser.Email;
                message.Subject = "Successfuly created order";
                message.Status = false;
            
                Order orderItem = new Order
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    User = loggedInUser
                };

                this._orderRepository.Insert(orderItem);

                List<BookInOrder> bookInOrders = new List<BookInOrder>();

                var result  = userShoppingcart.BookInShoppingCarts.Select(z => new BookInOrder
                {
                    Id = Guid.NewGuid(),
                    OrderId = orderItem.Id,
                    BookId = z.Book.Id,
                    SelectedBook = z.Book,
                    UserOrder = orderItem,
                    Quantity = z.Quantity
                }).ToList();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Your order is completed. The order contains: ");
                var totalPrice = 0.0;
                for(int i =1; i <= result.Count(); i++)
                {
                    var item = result[i - 1];
                    totalPrice += item.Quantity * item.SelectedBook.BookPrice;
                    sb.AppendLine(i.ToString() + ". " + item.SelectedBook.BookName + " with quantity of: " + item.Quantity + " and price of: $" + item.SelectedBook.BookPrice);

                }
                sb.AppendLine("Total price: " + totalPrice.ToString());
                message.Content = sb.ToString();
                
                bookInOrders.AddRange(result);

                foreach (var item in bookInOrders)
                {
                    this._bookInOrderRepository.Insert(item);
                }

                loggedInUser.UserCart.BookInShoppingCarts.Clear();

                this._mailRepository.Insert(message);
                this._userRepository.Update(loggedInUser);
                return true;

            }
            return false;

        }
    }
}
