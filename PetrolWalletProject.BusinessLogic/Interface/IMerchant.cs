using PetrolWalletProject.Domain.Dtos.Merchant;
using PetrolWalletProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolWalletProject.BusinessLogic.Interface
{
    public interface IMerchant
    {
        Task<APIListResponse3<Merchant>> GetMerchant(int pageNumber, int pageSize);
        Task<APIResponse<Merchant>> GetSingleMerchant(int Id);
        Task<APIResponse<CreateMerchantDto>> CreateMerchant(CreateMerchantDto request);
        Task<APIResponse<UpdateMerchantDto>> UpdateMerchant (UpdateMerchantDto request);
    }
}
