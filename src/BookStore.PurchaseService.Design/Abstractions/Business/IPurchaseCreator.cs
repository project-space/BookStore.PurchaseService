using BookStore.PurchaseService.Design.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.PurchaseService.Design.Abstractions.Business
{
    public interface IPurchaseCreator
    {
        Task AddPurchaseItems(List<int> bookIds, int purchaseId);
        Task<int> CreatePurchase(Order order);
    }
}
