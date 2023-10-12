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
    public class CustomerDbService
    {
        private readonly IDbConnection _connection;

        public CustomerDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreateCustomer (Customer request)
        {
            try
            {
                var query = @"[InsertInto_Customers]";
                var param = new
                {
                    CustomerName = request.CustomerName,
                    CustomerAddress = request.CustomerAddress,
                    CustomerPhoneNo = request.CustomerPhoneNo,
                };

                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }


        public async Task<Customer> SingleCustomer (int Id)
        {
            Customer customers = new Customer();
            try
            {
                var query = @"[GetCustomers]";
                var param = new { Id = Id };
                return await _connection.QueryFirstAsync<Customer>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements"))
                    return customers;
            }
            return null;
        }


        public async Task<APIListResponse3<Customer>> GetCustomers (int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Customer>();
            try
            {
                var query = @"[GetAllCustomers]";
                var param = new { pageNumber = pageNumber, pageSize = pageSize };
                var result = await _connection.QueryAsync<Customer>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<Customer>.ToPagedList(result, pageNumber, pageSize);
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


        public async Task<int> UpdateCustomers (Customer request)
        {
            try
            {
                var query = @"[Update_Customers]";
                var param = new
                {
                    CustomerName = request.CustomerName,
                    CustomerAddress = request.CustomerAddress,
                    CustomerPhoneNo = request.CustomerPhoneNo,
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
