using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolWalletProject.Domain.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? Narration { get; set; }
        public string UserUniqueNumber { get; set; }
        public string MerchantUniqueNumber { get; set; }
        public double Amount { get; set; }
        public ProductCategory? ProductCategory { get; set; }



    }

    public enum ProductCategory
    {
        PMS,
        Diesel,
        Kerosene,
        Gas,
    }

}
