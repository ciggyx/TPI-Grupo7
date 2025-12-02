using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using source.Application.UseCases;
using source.Infrastructure.Repositories;
using source.Infrastructure.Seeding;
using source.Repositorios;

namespace source
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            using (var scope = host.Services.CreateScope())
            {
                var staticSeeder = scope.ServiceProvider.GetRequiredService<StaticDataSeeder>();
                staticSeeder.SeedAsync().Wait();

                var appSeeder = scope.ServiceProvider.GetRequiredService<AppDataSeeder>();
                appSeeder.SeedAsync().Wait();

                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();
            }

            ApplicationConfiguration.Initialize();

            var mainForm = host.Services.GetRequiredService<MainInterface>();
            System.Windows.Forms.Application.Run(mainForm);
        }

        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(
                    (context, config) =>
                    {
                        config.AddJsonFile(
                            "appsettings.json",
                            optional: false,
                            reloadOnChange: true
                        );
                    }
                )
                .ConfigureServices(
                    (context, services) =>
                    {
                        var cs = context.Configuration.GetConnectionString("DefaultConnection");

                        // DbContext
                        services.AddDbContext<AppDbContext>(options =>
                        {
                            options.UseNpgsql(cs);
                        });

                        // Repositorios
                        services.AddScoped<IRepositorioAlcanceSismo, RepositorioAlcanceSismo>();
                        services.AddScoped<IRepositorioCambioEstado, RepositorioCambioEstado>();
                        services.AddScoped<
                            IRepositorioClasificacionSismo,
                            RepositorioClasificacionSismo
                        >();
                        services.AddScoped<
                            IRepositorioDetalleMuestraSismica,
                            RepositorioDetalleMuestraSismica
                        >();
                        services.AddScoped<IRepositorioEmpleado, RepositorioEmpleado>();
                        services.AddScoped<
                            IRepositorioEstacionSismologica,
                            RepositorioEstacionSismologica
                        >();
                        services.AddScoped<IRepositorioEstado, RepositorioEstado>();
                        services.AddScoped<IRepositorioEventoSismico, RepositorioEventoSismico>();
                        services.AddScoped<
                            IRepositorioMagnitudRichter,
                            RepositorioMagnitudRichter
                        >();
                        services.AddScoped<IRepositorioMuestraSismica, RepositorioMuestraSismica>();
                        services.AddScoped<
                            IRepositorioOrigenDeGeneracion,
                            RepositorioOrigenDeGeneracion
                        >();
                        services.AddScoped<IRepositorioSerieTemporal, RepositorioSerieTemporal>();
                        services.AddScoped<IRepositorioSesion, RepositorioSesion>();
                        services.AddScoped<IRepositorioSismografo, RepositorioSismografo>();
                        services.AddScoped<IRepositorioTipoDeDato, RepositorioTipoDeDato>();
                        services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

                        // Seeder
                        services.AddScoped<StaticDataSeeder>();
                        services.AddScoped<AppDataSeeder>();
                        services.AddScoped<IUnitOfWork, UnitOfWork>();

                        // Forms
                        services.AddScoped<MainInterface>();

                        // Gestor
                        services.AddTransient<GestorRegistrarRevisionManual>();
                    }
                );
    }
}
