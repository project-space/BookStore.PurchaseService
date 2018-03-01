using BookStore.PurchaseService.Design.Abstractions.DataAccess;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        public async Task<int> CreateCart(Cart cart)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var createdCart = await db.QueryAsync<int>(@"INSERT INTO Cart (AccountId, GuestId) VALUES(@AccountId, @GuestId);
                                    select scope_identity();", cart).ConfigureAwait(false);
                return createdCart.Single();
            }
        }

        public async Task<int> AddItem(CartItem item)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
               var createdItem = await db.QueryAsync<int>(@"INSERT INTO CartItem(CartId, BookId) VALUES(@CartId, @BookId);
                                          select scope_identity();", item).ConfigureAwait(false);
                return createdItem.Single();
            }
        }

        public async Task DeleteItem(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "delete from CartItem where Id = @id";
                await db.ExecuteAsync(sqlQuery, new { id }).ConfigureAwait(false);
            }
        }

        public async Task<List<CartItem>> GetItems(int cartId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var items = await db.QueryAsync<CartItem>("select * from CartItem where CartId=@cartId", new { cartId }).ConfigureAwait(false);
                return items.ToList();
            }
        }      
    }
}
