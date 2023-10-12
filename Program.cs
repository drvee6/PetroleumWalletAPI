using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PetrolWalletProject.BusinessLogic.Interface;
using PetrolWalletProject.BusinessLogic.Repository;
using PetrolWalletProject.DataAccess;
using System.Data;

namespace PetrolWalletProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddTransient<IDbConnection>(prov => new SqlConnection(prov.GetService<IConfiguration>().GetConnectionString("DefaultConnection")));




            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICustomer, CustomerRepo>();
            builder.Services.AddScoped<IMerchant, MerchantRepo>();
            builder.Services.AddScoped<ITransaction, TransactionRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}