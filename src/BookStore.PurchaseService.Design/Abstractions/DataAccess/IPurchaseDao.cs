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
        int CreateAdress(Adress adress);
        int CreatePurchaseDetails(PurchaseDetails details);
    }
}
