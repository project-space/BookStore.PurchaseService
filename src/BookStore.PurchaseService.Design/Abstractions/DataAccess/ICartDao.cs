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
        int CreateCart(Cart cart);
        void AddItem(CartItem item);
        List<CartItem> GetItems(int cartId);
        void DeleteItem(int id);
    }
}
