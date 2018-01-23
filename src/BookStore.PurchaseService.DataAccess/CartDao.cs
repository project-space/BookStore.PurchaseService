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
        private readonly string connectionString;

        public CartDao(IConnectionStringGetter connectionStringGetter)
        {
            this.connectionString = connectionStringGetter.Get();
        }
        public int CreateCart(Cart cart)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<int>(@"INSERT INTO Cart (AccountId, GuestId) VALUES(@AccountId, @GuestId);
                                    select scope_identity();", cart).Single();
            }
        }

        public void AddItem(CartItem item)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(@"INSERT INTO CartItem(CartId, BookId) VALUES(@CartId, @BookId);", item);
            }
        }

        public void DeleteItem(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "delete from CartItem where Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public List<CartItem> GetItems(int cartId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<CartItem>("select * from CartItem where CartId=@cartId", new { cartId }).ToList();
            }
        }

       
        
    }
}
