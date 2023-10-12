using AutoMapper;
using Newtonsoft.Json;
using PetrolWalletProject.BusinessLogic.Interface;
using PetrolWalletProject.DataAccess.Database;
using PetrolWalletProject.Domain.Dtos;
using PetrolWalletProject.Domain.Dtos.Merchant;
using PetrolWalletProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolWalletProject.BusinessLogic.Repository
{
    public class MerchantRepo : IMerchant
    {
        private readonly IDbConnection _connection;
        private readonly MerchantDbService service;
        private readonly IMapper _mapper;
        public MerchantRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            service = new MerchantDbService(connection);
        }

        public async Task<APIResponse<CreateMerchantDto>> CreateMerchant(CreateMerchantDto request)
        {
            var response = new APIResponse<CreateMerchantDto>();
            var model = _mapper.Map<Merchant>(request);
            var result = await service.CreateMerchant(model);

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

        public async Task<APIListResponse3<Merchant>> GetMerchant(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Merchant>();
            var result = await service.GetMerchants(pageNumber, pageSize);
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

        public async Task<APIResponse<Merchant>> GetSingleMerchant(int Id)
        {
            var response = new APIResponse<Merchant>();
            var result = await service.SingleMerchant(Id);

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

        public async Task<APIResponse<UpdateMerchantDto>> UpdateMerchant(UpdateMerchantDto request)
        {
            var response = new APIResponse<UpdateMerchantDto>();
            var model = _mapper.Map<Merchant>(request);
            var result = await service.UpdateMerchants(model);

            if (result == 1)
            {
                response.Code = "00";
                response.Description = "Successful";
                response.Data = request;
            }
            else
            {
                response.Code = "99";
                response.Description = "An error occured, Please try again later";
            }
            return response;
        }
    }
}
