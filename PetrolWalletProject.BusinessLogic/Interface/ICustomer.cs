using PetrolWalletProject.Domain.Dtos;
using PetrolWalletProject.Domain.Dtos.Merchant;
using PetrolWalletProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolWalletProject.BusinessLogic.Interface
{
    public interface ICustomer
    {
        Task<APIListResponse3<Customer>> GetCustomers (int pageNumber, int pageSize);
        Task<APIResponse<Customer>> GetSingleCustomers (int Id);
        Task<APIResponse<CreateCustomerDto>> CreateCustomers (CreateCustomerDto request);
        Task<APIResponse<UpdateCustomerDto>> UpdateCustomers (UpdateCustomerDto request);
    }
}
