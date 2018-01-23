using BookStore.PurchaseService.Business;
using BookStore.PurchaseService.Design.Abstractions.Business;
using BookStore.PurchaseService.Design.Models;
using System.Web.Http;
using System.Web.Http.Results;

namespace BookStore.PurchaseService.Api.Controllers
{
    [RoutePrefix("api/cart")]
    public class CartController : ApiController
    {
        private readonly ICartCreator cartCreator;

        public CartController(ICartCreator cartCreator)
        {
            this.cartCreator = cartCreator;
        }

        [HttpGet]
        public JsonResult<Cart> CreateCart() => Json(cartCreator.Create());
    }
}
