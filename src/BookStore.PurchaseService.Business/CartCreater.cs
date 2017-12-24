using BookStore.PurchaseService.DataAccess;
using BookStore.PurchaseService.Design.Abstractions.Business;
using BookStore.PurchaseService.Design.Abstractions.DataAccess;
using BookStore.PurchaseService.Design.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.PurchaseService.Business
{
    public class CartCreater : ICartCreater
    {
        ICartDao cartDao = new CartDao();
        public Cart Create()
        {
            var guestId = Guid.NewGuid();
            var cart = new Cart {GuestId = guestId.ToString()};
            cart.Id = cartDao.CreateCart(cart);

            return cart;
        }
    }
}
