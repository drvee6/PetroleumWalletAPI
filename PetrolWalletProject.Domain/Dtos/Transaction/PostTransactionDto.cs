using PetrolWalletProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolWalletProject.Domain.Dtos.Transaction
{
    public class PostTransactionDto
    {
        public string? Narration { get; set; }
        public string UserUniqueNumber { get; set; }
        public string MerchantUniqueNumber { get; set; }
        public double Amount { get; set; }
        public ProductCategory? ProductCategory { get; set; }
    }
}
