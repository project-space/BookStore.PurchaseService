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
        Task AddPurchaseItems(List<PurchaseItem> items);
        Task<int> CreatePurchase(Purchase purchase);
        Task<int> CreateAdress(Adress adress);
        Task<int> CreatePurchaseDetails(PurchaseDetails details);
    }
}
