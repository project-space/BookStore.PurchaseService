using BookStore.PurchaseService.Design.Abstractions.DataAccess;
using BookStore.PurchaseService.Design.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<int> AddCartItem(CartItem item)
        {
            return await cartDao.AddItem(item).ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("api/cart-items/delete/{id}")]
        public async Task DeleteCartItem(int id)
        {
            await cartDao.DeleteItem(id).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("api/cart-items/getitems/{cartId}")]
        public async Task<List<CartItem>> GetItems(int cartId)
        {
            return await cartDao.GetItems(cartId).ConfigureAwait(false);
        }
    }
}
