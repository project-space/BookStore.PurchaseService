using BookStore.PurchaseService.Design.Abstractions.Business;
using BookStore.PurchaseService.Design.Abstractions.DataAccess;
using BookStore.PurchaseService.Design.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.PurchaseService.Business
{
    public class PurchaseCreator : IPurchaseCreator
    {
        private readonly IPurchaseDao purchaseDao;

        public PurchaseCreator(IPurchaseDao purchaseDao)
        {
            this.purchaseDao = purchaseDao;
        }

        public async Task AddPurchaseItems(List<int> bookIds, int purchaseId)
        {
            var items = new List<PurchaseItem>();
            foreach (var id in bookIds)
            {
                items.Add(new PurchaseItem {
                    PurchaseId = purchaseId,
                    BookId = id
                    });
                }

            await purchaseDao.AddPurchaseItems(items).ConfigureAwait(false);
        }

        public async Task<int> CreatePurchase(Order order)
        {
            var adressId = await CreateAdress(order).ConfigureAwait(false);
            var purchaseDetailsId = await CreatePurchaseDetails(order, adressId).ConfigureAwait(false);
            var purchase = new Purchase
            {
                AccountId = order.AccountId,
                GuestId = order.GuestId,
                PurchaseDetailsId = purchaseDetailsId
            };

            return await purchaseDao.CreatePurchase(purchase).ConfigureAwait(false);
        }

        private async Task<int> CreateAdress(Order order)
        {
            var adress = new Adress
            {
                Postcode = order.Postcode,
                Town = order.Town,
                Street = order.Street,
                House = order.House,
                Apartment = order.Apartment,
                PhoneNumber = order.PhoneNumber
            };
            
            return await purchaseDao.CreateAdress(adress).ConfigureAwait(false);
        }

        private async Task<int> CreatePurchaseDetails(Order order, int adressId)
        {
            var details = new PurchaseDetails
            {
                FullName = order.FullName,
                AdressId = adressId
            };

            return await purchaseDao.CreatePurchaseDetails(details).ConfigureAwait(false);
        }
    }
}
