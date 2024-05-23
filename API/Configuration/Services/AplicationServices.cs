using Application.Core;
using Application.Establishiment;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Configuration.Services {
    public static class AplicationServices {


        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration config) {

           
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
           services.AddEndpointsApiExplorer();
           services.AddSwaggerGen();

           services.AddDbContext<DataContext>(opt => {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(List.Handler).Assembly));
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);


            return services;
        }

    }
}
