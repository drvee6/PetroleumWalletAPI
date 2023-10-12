using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolWalletProject.Domain.Dtos.Merchant
{
    public class UpdateMerchantDto
    {
        public int Id { get; set; }
        public string MerchantName { get; set; }
        public string MerchantAddress { get; set; }
        public string MerchantPhoneNo { get; set; }
    }
}
