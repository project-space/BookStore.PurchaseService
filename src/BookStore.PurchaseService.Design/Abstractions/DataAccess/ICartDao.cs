using BookStore.PurchaseService.Design.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.PurchaseService.Design.Abstractions.DataAccess
{
    public interface ICartDao
    {
        Task<int> CreateCart(Cart cart);
        Task AddItem(CartItem item);
        Task<List<CartItem>> GetItems(int cartId);
        Task DeleteItem(int id);
    }
}
