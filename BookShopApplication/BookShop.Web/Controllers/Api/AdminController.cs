using BookShop.Domain.DomainModels;
using BookShop.Domain.DTO;
using BookShop.Domain.Identity;
using BookShop.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IOrderService _orderService;
        private readonly UserManager<BookShopAppUser> userManager;
        public AdminController(IOrderService orderService, UserManager<BookShopAppUser> userManager)
        {
            this._orderService = orderService;
            this.userManager = userManager;
        }
          [HttpGet("[action]")]
        public List<Order> GetAllActiveOrders()
        {
            return this._orderService.getAllOrders();

        }
        [HttpPost("[action]")]
        public Order GetDetailsForOrder(BaseEntity model)
        {
            return this._orderService.getOrderDetails(model);

        }
        [HttpPost("[action]")]
        public bool ImportAllUsers(List<UserRegistrationDto> model)
        {
            bool status = true;
         foreach(var item in model)
            {
                var userCheck =  userManager.FindByEmailAsync(item.Email).Result;
                if(userCheck == null)
                {
                    var user = new BookShopAppUser
                    {

                        FirstName = item.Name,
                        LastName = item.LastName,
                        UserName = item.Email,
                        NormalizedUserName = item.Email,
                        Email = item.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        PhoneNumber = item.PhoneNumber,
                        UserCart = new ShoppingCart()
                    };
                    var result =  userManager.CreateAsync(user, item.Password).Result;
                    status = status && result.Succeeded;
                }
                else
                {
                    continue;
                }
            }
            return status;

        }
    }
}
