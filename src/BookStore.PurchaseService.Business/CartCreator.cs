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
    public class CartCreator : ICartCreator
    {
        private readonly ICartDao cartDao;

        public CartCreator(ICartDao cartDao)
        {
            this.cartDao = cartDao;
        }

        public async Task<Cart> Create()
        {
            var guestId = Guid.NewGuid();
            var cart = new Cart {GuestId = guestId.ToString()};
            cart.Id = await cartDao.CreateCart(cart).ConfigureAwait(false);

            return cart;
        }
    }
}
