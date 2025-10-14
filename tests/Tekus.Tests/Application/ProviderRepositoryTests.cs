using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Domain.Entities;
using Tekus.Persistence;
using Tekus.Persistence.Repositories;

namespace Tekus.Tests.Application
{
    public class ProviderRepositoryTests
    {
        [Fact]
        public async Task AddService_ShouldSaveCorrectly()
        {
            var options = new DbContextOptionsBuilder<TekusDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_AddProvider")
                .Options;

            using var context = new TekusDbContext(options);
            var repo = new ProviderRepository(context);

            var provider = new Provider
            (
                name: "Pepe",
                nit: "1199887755",
                email: "email@correo.com"
                
            );

            await repo.AddAsync(provider);
            await context.SaveChangesAsync();

            var result = await repo.GetByIdAsync(provider.Id);

            result.Should().NotBeNull();
            result!.Name.Should().Be("Pepe");
        }
    }
}
