using BookStore.PurchaseService.Design.Abstractions.Business;
using BookStore.PurchaseService.Design.Models;
using System.Threading.Tasks;
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
        public async Task<int> Create(Order order)
        {
            var purchaseId = await purchaseCreator.CreatePurchase(order).ConfigureAwait(false);
            await purchaseCreator.AddPurchaseItems(order.BookIds, purchaseId).ConfigureAwait(false);
            return purchaseId;
        }
    }
}