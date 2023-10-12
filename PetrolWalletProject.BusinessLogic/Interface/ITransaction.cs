using PetrolWalletProject.Domain.Dtos;
using PetrolWalletProject.Domain.Dtos.Transaction;
using PetrolWalletProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolWalletProject.BusinessLogic.Interface
{
    public interface ITransaction
    {
        Task<APIListResponse3<Transaction>> GetTransactions (int pageNumber, int pageSize);
        Task<APIResponse<Transaction>> GetSingleTransactions (int Id);
        Task<APIResponse<PostTransactionDto>> PostTransactions (PostTransactionDto request);
        
    }
}
