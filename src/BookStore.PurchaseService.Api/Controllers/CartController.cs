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
        ICartCreater cartCreater = new CartCreater();

        [HttpGet]
        public JsonResult<Cart> CreateCart() => Json(cartCreater.Create());
    }
}
