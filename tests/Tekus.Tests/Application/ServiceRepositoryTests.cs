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
    public class ServiceRepositoryTests
    {
        [Fact]
        public async Task AddService_ShouldSaveCorrectly()
        {
            var options = new DbContextOptionsBuilder<TekusDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_AddService")
                .Options;

            using var context = new TekusDbContext(options);
            var repo = new ServiceRepository(context);

            var service = new Service
            (
                name: "City Tour",
                hourlyRate: 10,
                providerId: 1,
                countries: new List<string> { "AR", "CO" }
            );

            await repo.AddAsync(service);
            await context.SaveChangesAsync();

            var result = await repo.GetByIdAsync(service.Id);

            result.Should().NotBeNull();
            result!.Name.Should().Be("City Tour");
        }
    }
}
