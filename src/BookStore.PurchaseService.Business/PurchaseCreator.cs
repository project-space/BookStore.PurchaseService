using BookStore.PurchaseService.DataAccess;
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
    public class PurchaseCreator : IPurchaseCreator
    {
        IPurchaseDao purchaseDao = new PurchaseDao();

        public void AddPurchaseItems(List<int> bookIds, int purchaseId)
        {
            var items = new List<PurchaseItem>();
            foreach (var id in bookIds)
            {
                items.Add(new PurchaseItem {
                    PurchaseId = purchaseId,
                    BookId = id
                    });
                }
            purchaseDao.AddPurchaseItems(items);
        }

        public int CreatePurchase(Order order)
        {
            var adressId = CreateAdress(order);
            var purchaseDetailsId = CreatePurchaseDetails(order, adressId);
            var purchase = new Purchase
            {
                AccountId = order.AccountId,
                GuestId = order.GuestId,
                PurchaseDetailsId = purchaseDetailsId
            };

            return purchaseDao.CreatePurchase(purchase);
        }

        private int CreateAdress(Order order)
        {
            var adress = new Adress
            {
                Postcode = order.Postcode,
                Country = order.Country,
                City = order.City,
                Street = order.Street,
                House = order.House,
                Apartment = order.Apartment,
                PhoneNumber = order.PhoneNumber
            };
            
            return purchaseDao.CreateAdress(adress);
        }

        private int CreatePurchaseDetails(Order order, int adressId)
        {
            var details = new PurchaseDetails
            {
                FullName = order.FullName,
                AdressId = adressId
            };
            return purchaseDao.CreatePurchaseDetails(details);
        }
    }
}
