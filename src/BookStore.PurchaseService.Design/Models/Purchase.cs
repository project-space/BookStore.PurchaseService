using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.PurchaseService.Design.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string GuestId { get; set; }
        public int PurchaseDetailsId { get; set; }
    }
}
