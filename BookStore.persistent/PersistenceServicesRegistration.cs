using BookStore.Application.Contracts.Persistence;
using BookStore.persistent.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.persistent
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookStoreDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("BookStoreAppDbConnection")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            

            return services;
        }
    }
}
