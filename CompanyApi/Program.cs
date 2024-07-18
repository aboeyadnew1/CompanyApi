
using Company.Business.Mapping;
using Company.Business.Service.CustomerService;
using Company.Business.Service.DepartmentServices;
using Company.Business.Service.EmployeeServices;
using Company.Business.Service.OrderService;
using Company.Business.Service.ProductService;
using Company.DataAccess.Data;
using Company.DataAccess.Repos.CustomerRepo;
using Company.DataAccess.Repos.DepartmentRepo;
using Company.DataAccess.Repos.EmployeeRepo;
using Company.DataAccess.Repos.OrderRepo;
using Company.DataAccess.Repos.ProductRepo;
using Microsoft.EntityFrameworkCore;

namespace CompanyApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // إضافة AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            //***************************************************************************//
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IEmployeeServices , EmployeeServices>();  
            builder.Services.AddScoped<IEmployeeRepo , EmployeeRepo>();      
            builder.Services.AddScoped<IDepartmentService , DepartmentService>();  
            builder.Services.AddScoped<IDepartmentRepository , DepartmentRepository>();     
            builder.Services.AddScoped<ICustomerService , CustomerService>();  
            builder.Services.AddScoped<ICustomerRepository , CustomerRepository>();
            builder.Services.AddScoped<IOrderServices, OrderServices>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            //***************************************************************************//
            builder.Services.AddDbContext<ApplicationDbContext>(option => option
                .UseSqlServer(builder.Configuration
                .GetConnectionString("DefaultConnection")));
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
