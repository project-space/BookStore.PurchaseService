using BookStore.PurchaseService.Business;
using BookStore.PurchaseService.Design.Abstractions.Business;
using BookStore.PurchaseService.Design.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BookStore.PurchaseService.Api.Controllers
{
    public class PurchaseController : ApiController
    {
        static IPurchaseCreator purchaseCreator = new PurchaseCreator();

        [HttpPost, Route("api/purchase/create")]
        public int Create(Order order)
        {
            var purchaseId = purchaseCreator.CreatePurchase(order);
            purchaseCreator.AddPurchaseItems(order.BookIds, purchaseId);
            return purchaseId;
        }
    }
}