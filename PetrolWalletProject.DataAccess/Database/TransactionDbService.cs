using Dapper;
using PetrolWalletProject.Domain.Models;
using PetrolWalletProject.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolWalletProject.DataAccess.Database
{
    public class TransactionDbService
    {
        private readonly IDbConnection _connection;

        public TransactionDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreateTransaction(Transaction request)
        {
            try
            {
                var query = @"[InsertInto_Transactions]";
                var param = new
                {
                    Narration = request.Narration,
                    UserUniqueNumber = request.UserUniqueNumber,
                    MerchantUniqueNumber = request.MerchantUniqueNumber,
                    Amount = request.Amount,
                    ProductCategory = request.ProductCategory
                };

                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }


        public async Task<Transaction> SingleTransactions (int Id)
        {
            Transaction transactions = new Transaction();
            try
            {
                var query = @"[GetTransactions]";
                var param = new { Id = Id };
                return await _connection.QueryFirstAsync<Transaction>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements"))
                    return transactions;
            }
            return null;
        }


        public async Task<APIListResponse3<Transaction>> GetTransactions(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Transaction>();
            try
            {
                var query = @"[GetAllTransactions]";
                var param = new { pageNumber = pageNumber, pageSize = pageSize };
                var result = await _connection.QueryAsync<Transaction>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<Transaction>.ToPagedList(result, pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Sequence contatins no elements"))
                {
                    response.Code = "01";
                }
            }
            return response;
        }


       
    }
}
