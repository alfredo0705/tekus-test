using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Api;
using Tekus.Identity;
using Tekus.Persistence;

namespace Tekus.Tests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                //// Eliminar registros previos del contexto principal
                //var tekusDescriptor = services.SingleOrDefault(
                //    d => d.ServiceType == typeof(DbContextOptions<TekusDbContext>));
                //if (tekusDescriptor != null)
                //    services.Remove(tekusDescriptor);

                //// Eliminar registros previos del contexto Identity
                //var identityDescriptor = services.SingleOrDefault(
                //    d => d.ServiceType == typeof(DbContextOptions<TekusIdentityDbContext>));
                //if (identityDescriptor != null)
                //    services.Remove(identityDescriptor);

                //// Registrar ambos contextos en memoria
                //services.AddDbContext<TekusDbContext>(options =>
                //    options.UseInMemoryDatabase("TekusTestDb"));

                //services.AddDbContext<TekusIdentityDbContext>(options =>
                //    options.UseInMemoryDatabase("TekusIdentityTestDb"));

                // Reconstruir proveedor
                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;

                var tekusDb = scopedServices.GetRequiredService<TekusDbContext>();
                var identityDb = scopedServices.GetRequiredService<TekusIdentityDbContext>();

                // Asegurar limpieza y creación
                tekusDb.Database.EnsureDeleted();
                tekusDb.Database.EnsureCreated();

                identityDb.Database.EnsureDeleted();
                identityDb.Database.EnsureCreated();
            });
        }

        //private static void SeedData(TekusDbContext db)
        //{
        //    // Ejemplo opcional
        //    if (!db.Providers.Any())
        //    {
        //        db.Providers.Add(new Tekus.Domain.Entities.Provider
        //        {
        //            Name = "Proveedor Demo",
        //            Email = "demo@tekus.com",
        //            Nit = "123456",
        //            Country = "Colombia"
        //        });
        //        db.SaveChanges();
        //    }
        //}
    }
}