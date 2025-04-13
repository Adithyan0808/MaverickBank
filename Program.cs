
using MaverickBankReal.Context;
using MaverickBankReal.Interfaces.RepoInterface;
using MaverickBankReal.Interfaces;
using MaverickBankReal.Mapper;
using MaverickBankReal.Repo;
using MaverickBankReal.Services;
using Microsoft.EntityFrameworkCore;


namespace MaverickBankReal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BankDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            #region Mappers
            builder.Services.AddAutoMapper(typeof(CustomerMapper));
            builder.Services.AddAutoMapper(typeof(AccountMapper));
            builder.Services.AddAutoMapper(typeof(AdminMapper));
            builder.Services.AddAutoMapper(typeof(TypeMasterMapper));
            #endregion


            #region Services
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IBranchService, BranchService>();
            builder.Services.AddScoped<IAccountTypeMasterService, AccountTypeMasterService>();
            builder.Services.AddScoped<ILoanTypeMasterService, LoanTypeMasterService>();
            builder.Services.AddScoped<ILoanStatusMasterService, LoanStatusMasterService>();
            builder.Services.AddScoped<ITransactionTypeMasterService, TransactionTypeMasterService>();
            #endregion




            #region Repositories
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<IBranchRepository, BranchRepository>();
            builder.Services.AddScoped<IAccountTypeMasterRepository, AccountTypeMasterRepository>();
            builder.Services.AddScoped<ILoanTypeMasterRepository, LoanTypeMasterRepository>();
            builder.Services.AddScoped<ILoanStatusMasterRepository, LoanStatusMasterRepository>();
            builder.Services.AddScoped<ITransactionTypeMasterRepository, TransactionTypeMasterRepository>();


            #endregion


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
