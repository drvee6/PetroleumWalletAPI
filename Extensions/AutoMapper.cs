using AutoMapper;
using PetrolWalletProject.Domain.Dtos;
using PetrolWalletProject.Domain.Dtos.Merchant;
using PetrolWalletProject.Domain.Dtos.Transaction;
using PetrolWalletProject.Domain.Models;

namespace PetrolWalletProject.Extensions
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Customer, CreateCustomerDto>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<Customer, UpdateCustomerDto>();
            CreateMap<UpdateCustomerDto, Customer>();

            CreateMap<Merchant, CreateMerchantDto>();
            CreateMap<CreateMerchantDto, Merchant>();
            CreateMap<Merchant, UpdateMerchantDto>();
            CreateMap<UpdateMerchantDto, Merchant>();


            CreateMap<Transaction, PostTransactionDto>();
            CreateMap<PostTransactionDto, Transaction>();




        }
    }
}
