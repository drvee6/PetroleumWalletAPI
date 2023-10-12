using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolWalletProject.Domain.Models
{
    public class Merchant
    {
        public int Id { get; set; }

        public string? UniqueNumber { get; set; }
        public string MerchantName { get; set; }
        public string MerchantAddress { get; set; }
        public string MerchantPhoneNo { get; set; }
        public DateTime? DateRegistered { get; set; }
        public DateTime? LastUpdate { get; set; }
        public double? WalletBalance { get; set; }
    }
}
