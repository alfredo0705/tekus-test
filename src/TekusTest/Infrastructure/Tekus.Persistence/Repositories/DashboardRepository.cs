using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.DTOs.Dashboard;
using Tekus.Domain.Entities;

namespace Tekus.Persistence.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly TekusDbContext _context;

        public DashboardRepository(TekusDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardSummaryDto> GetSummary()
        {
            var providersByCountry = _context.Services
               .AsEnumerable()
               .SelectMany(s => s.Countries.Select(code => new { s.ProviderId, Country = code }))
               .Distinct()
               .GroupBy(x => x.Country)
               .Select(g => new CountryCountDto
               {
                   Country = g.Key,
                   Count = g.Select(x => x.ProviderId).Distinct().Count()
               })
               .ToList();

            var services = await _context.Services.ToListAsync();

            var servicesByCountry = services
                .SelectMany(s => s.Countries.Select(code => new { Country = code }))
                .GroupBy(x => x.Country)
                .Select(g => new CountryCountDto
                {
                    Country = g.Key,
                    Count = g.Count()
                })
                .ToList();

            var providers = await _context.Providers.ToListAsync();

            return new DashboardSummaryDto
            {
                TotalProviders = providers.Count,
                TotalServices = services.Count,
                ProvidersByCountry = providersByCountry,
                ServicesByCountry = servicesByCountry
            };
        }

    }
}
