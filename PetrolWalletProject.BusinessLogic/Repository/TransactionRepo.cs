using AutoMapper;
using Newtonsoft.Json;
using PetrolWalletProject.BusinessLogic.Interface;
using PetrolWalletProject.DataAccess.Database;
using PetrolWalletProject.Domain.Dtos;
using PetrolWalletProject.Domain.Dtos.Transaction;
using PetrolWalletProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolWalletProject.BusinessLogic.Repository
{
    public class TransactionRepo : ITransaction
    {
        private readonly IDbConnection _connection;
        private readonly TransactionDbService service;
        private readonly IMapper _mapper;
        public TransactionRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            service = new TransactionDbService(connection);
        }

        public async Task<APIResponse<Transaction>> GetSingleTransactions(int Id)
        {
            var response = new APIResponse<Transaction>();
            var result = await service.SingleTransactions(Id);

            if (result != null)
            {
                if (result.Id == 0)
                {
                    response.Code = "01";
                    response.Description = "No Record found";
                }
                else
                {
                    response.Code = "00";
                    response.Description = "Successful";
                    response.Data = result;
                }
            }
            else
            {
                response.Code = "01";
                response.Description = "No Record found";
            }
            return response;
        }

        public async Task<APIListResponse3<Transaction>> GetTransactions(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Transaction>();
            var result = await service.GetTransactions(pageNumber, pageSize);
            if (result != null)
            {
                if (result.Data.Count() > 0)
                {
                    var metadata = new
                    {
                        result.Data.TotalCount,
                        result.Data.PageSize,
                        result.Data.CurrentPage,
                        result.Data.TotalPages,
                        result.Data.HasNext,
                        result.Data.HasPrevious
                    };
                    response.PageInfo = JsonConvert.SerializeObject(metadata);
                    response.Code = "00";
                    response.Description = "Successful";
                    response.Data = result.Data;
                }
                else
                {
                    response.Code = "01";
                    response.Description = "No Record Found";
                }
            }
            else
            {
                response.Code = "99";
                response.Description = "An Error Occured, Please try again later";
            }
            return response;
        }


        public async Task<APIResponse<PostTransactionDto>> PostTransactions(PostTransactionDto request)
        {
            var response = new APIResponse<PostTransactionDto>();
            var model = _mapper.Map<Transaction>(request);
            var result = await service.CreateTransaction(model);

            if (result == 1)
            {
                response.Code = "00";
                response.Description = "Successful";
                response.Data = request;
            }
            else if (result == -1)
            {
                response.Code = "01";
                response.Description = "Record Already Exist";
            }
            else
            {
                response.Code = "99";
                response.Description = "An Error Occuried, Please try again later";
            }
            return response;
        }
    }
}
