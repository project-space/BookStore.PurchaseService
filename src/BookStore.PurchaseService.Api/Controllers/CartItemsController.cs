using BookStore.PurchaseService.DataAccess;
using BookStore.PurchaseService.Design.Abstractions.DataAccess;
using BookStore.PurchaseService.Design.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.PurchaseService.Api.Controllers
{
    public class CartItemsController : ApiController
    {
        private readonly ICartDao cartDao;
        
        public CartItemsController(ICartDao cartDao)
        {
            this.cartDao = cartDao;
        }

        [HttpPost]
        [Route("api/cart-items/add")]
        public void AddCartItem(CartItem item)
        {
            cartDao.AddItem(item);
        }


        [HttpDelete]
        [Route("api/cart-items/delete/{id}")]
        public void DeleteCartItem(int id)
        {
            cartDao.DeleteItem(id);
        }

        [HttpGet]
        [Route("api/cart-items/getitems/{cartId}")]
        public List<CartItem> GetItems(int cartId)
        {
            return cartDao.GetItems(cartId);
        }
    }
}
