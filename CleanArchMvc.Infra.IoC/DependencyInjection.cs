using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) //Extension method
        {
            //Registering context
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefautConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext) //migration will be located where my ApplycationDbContext is.
                .Assembly.FullName)));

            services.AddScoped<IProductRepository, ProductRepository>(); //Registering Repository
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
