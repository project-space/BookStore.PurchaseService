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
        ICartCreator cartCreator = new CartCreator();

        [HttpGet]
        public JsonResult<Cart> CreateCart() => Json(cartCreator.Create());
    }
}
