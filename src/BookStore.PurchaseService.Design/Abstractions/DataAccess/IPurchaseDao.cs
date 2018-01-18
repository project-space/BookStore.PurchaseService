using BookStore.PurchaseService.Design.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.PurchaseService.Design.Abstractions.DataAccess
{
    public interface IPurchaseDao
    {
        void AddPurchaseItems(List<PurchaseItem> items);
        int CreatePurchase(Purchase purchase);
        int CreateAdress(Adress adress);
        int CreatePurchaseDetails(PurchaseDetails details);
    }
}
