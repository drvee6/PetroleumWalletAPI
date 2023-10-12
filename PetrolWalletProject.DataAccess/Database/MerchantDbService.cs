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
    public class MerchantDbService
    {
        private readonly IDbConnection _connection;

        public MerchantDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreateMerchant(Merchant request)
        {
            try
            {
                var query = @"[InsertInto_Merchants]";
                var param = new
                {
                    MerchantName = request.MerchantName,
                    MerchantAddress = request.MerchantAddress,
                    MerchantPhoneNo = request.MerchantPhoneNo,
                };

                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }


        public async Task<Merchant> SingleMerchant(int Id)
        {
            Merchant merchants = new Merchant();
            try
            {
                var query = @"[GetMerchants]";
                var param = new { Id = Id };
                return await _connection.QueryFirstAsync<Merchant>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements"))
                    return merchants;
            }
            return null;
        }


        public async Task<APIListResponse3<Merchant>> GetMerchants(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Merchant>();
            try
            {
                var query = @"[GetAllMerchants]";
                var param = new { pageNumber = pageNumber, pageSize = pageSize };
                var result = await _connection.QueryAsync<Merchant>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<Merchant>.ToPagedList(result, pageNumber, pageSize);
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


        public async Task<int> UpdateMerchants(Merchant request)
        {
            try
            {
                var query = @"[Update_Merchants]";
                var param = new
                {
                    MerchantName = request.MerchantName,
                    MerchantAddress = request.MerchantAddress,
                    MerchantPhoneNo = request.MerchantPhoneNo,
                    Id = request.Id
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

    }
}
