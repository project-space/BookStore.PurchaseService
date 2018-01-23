using BookStore.PurchaseService.Design.Abstractions.Business;
using BookStore.PurchaseService.Design.Models;
using System.Web.Http;

namespace BookStore.PurchaseService.Api.Controllers
{
    public class PurchaseController : ApiController
    {
        private readonly IPurchaseCreator purchaseCreator;

        public PurchaseController(IPurchaseCreator purchaseCreator)
        {
            this.purchaseCreator = purchaseCreator;
        }

        [HttpPost, Route("api/purchase/create")]
        public int Create(Order order)
        {
            var purchaseId = purchaseCreator.CreatePurchase(order);
            purchaseCreator.AddPurchaseItems(order.BookIds, purchaseId);
            return purchaseId;
        }
    }
}