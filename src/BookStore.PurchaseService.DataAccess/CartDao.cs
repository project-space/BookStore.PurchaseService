using BookStore.PurchaseService.Design.Abstractions.DataAccess;
using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.PurchaseService.Design.Models;

namespace BookStore.PurchaseService.DataAccess
{
    public class CartDao : ICartDao
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStore.Purchase;Integrated Security=True;";

        public int CreateCart(Cart cart)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<int>(@"INSERT INTO Cart (AccountId, GuestId) VALUES(@AccountId, @GuestId);
                                    select scope_identity();", cart).Single();
            }
        }

        
    }
}
