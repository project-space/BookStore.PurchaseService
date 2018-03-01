using BookStore.PurchaseService.Design.Abstractions.DataAccess;
using BookStore.PurchaseService.Design.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.PurchaseService.DataAccess
{
    public class PurchaseDao : IPurchaseDao
    {
        private readonly string connectionString;

        public PurchaseDao(IConnectionStringGetter connectionStringGetter)
        {
            this.connectionString = connectionStringGetter.Get();
        }

        public async Task<int> CreatePurchase(Purchase purchase)
        {

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var createdPurchase = await db.QueryAsync<int>(@"INSERT INTO Purchase (AccountId, GuestId, PurchaseDetailsId) 
                                       VALUES(@AccountId, @GuestId, @PurchaseDetailsId);
                                       select scope_identity();", purchase).ConfigureAwait(false);
                return createdPurchase.Single();
            }
        }

        public async Task AddPurchaseItems(List<PurchaseItem> items)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                foreach (var item in items)
                {
                    await db.ExecuteAsync(@"INSERT INTO PurchaseItem (BookId, PurchaseId) 
                                       VALUES(@BookId,@PurchaseId);", item).ConfigureAwait(false);
                }
            }
        }

        

        public async Task<int> CreateAdress(Adress adress)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var createdAdress = await db.QueryAsync<int>(@"INSERT INTO Adress (Postcode, Country, City, Street, House, Apartment, PhoneNumber) 
                                       VALUES(@Postcode, @Country, @City, @Street, @House, @Apartment, @PhoneNumber);
                                       select scope_identity();", adress).ConfigureAwait(false);
                return createdAdress.Single();
            }
        }

        public async Task<int> CreatePurchaseDetails(PurchaseDetails details)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var createdDetails = await db.QueryAsync<int>(@"INSERT INTO PurchaseDetails (FullName, AdressId) 
                                       VALUES(@FullName, @AdressId);
                                       select scope_identity();", details).ConfigureAwait(false);
                return createdDetails.Single();
            }
        }

    }
}
