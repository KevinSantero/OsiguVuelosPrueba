using Aplicacion.Queries;
using Dominio.Abstracciones;
using Dominio.Usuario;
using Dominio.Vuelos;
using Infraestructura.Queries;
using Infraestructura.Repositorios;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlKata.Compilers;
using System.Data;

namespace Infraestructura
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                 ?? throw new ArgumentNullException(nameof(configuration));

            //Entity
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
            
            //Sql Kata
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });

            services.AddScoped<IUnitOfWork, ContainerUnitOfWork>();
            services.AddScoped<IRepository, Repository>();
        
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVueloRepository, VueloRepository>();


            //IQueries
            services.AddTransient<ICiudadQueries, CuiudadQueries>();
            services.AddTransient<IAereoliniaQueries, AereoliniaQueries>();
            services.AddTransient<IVueloQueries, VuelosQueries>();


            //services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            return services;
        }

    }
}
