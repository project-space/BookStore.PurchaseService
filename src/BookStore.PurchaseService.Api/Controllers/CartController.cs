using BookStore.PurchaseService.Business;
using BookStore.PurchaseService.Design.Abstractions.Business;
using BookStore.PurchaseService.Design.Models;
using System.Web.Http;

namespace BookStore.PurchaseService.Api.Controllers
{
    [RoutePrefix("api/cart")]
    public class CartController : ApiController
    {
        ICartCreater cartCreater = new CartCreater();

        [HttpGet]
        public Cart CreateCart() => cartCreater.Create();
    }
}
