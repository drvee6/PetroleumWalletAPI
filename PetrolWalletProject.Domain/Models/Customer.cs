using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolWalletProject.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string? UniqueNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNo { get; set; }
        public DateTime? DateRegistered { get; set; }

        public DateTime? LastUpdate {  get; set; }
        public double? WalletBalance { get; set; }
    }
}
