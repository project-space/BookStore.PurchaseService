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
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStore.Purchase;Integrated Security=True;";

        public int CreateAdress(Adress adress)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<int>(@"INSERT INTO Adress (Postcode, Country, City, Street, House, Apartment, PhoneNumber) 
                                       VALUES(@Postcode, @Country, @City, @Street, @House, @Apartment, @PhoneNumber);
                                       select scope_identity();", adress).Single();
            }
        }

        public int CreatePurchaseDetails(PurchaseDetails details)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<int>(@"INSERT INTO PurchaseDetails (FullName, AdressId) 
                                       VALUES(@FullName, @AdressId);
                                       select scope_identity();", details).Single();
            }
        }

    }
}
