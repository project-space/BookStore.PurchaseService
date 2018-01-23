using BookStore.PurchaseService.Design.Abstractions.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.PurchaseService.DataAccess
{
    public class ConnectionStringGetter : IConnectionStringGetter
    {
        public string Get()
        {
            return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStore.Purchase;Integrated Security=True;";
        }
    }
}
