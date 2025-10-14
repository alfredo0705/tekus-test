using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tekus.Tests.Helpers;

namespace Tekus.Tests.Integration
{
    public class ServicesControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ServicesControllerIntegrationTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
            var token = TokenHelper.GenerateTestJwt();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        [Fact]
        public async Task GetServices_ShouldReturnOk()
        {
            var response = await _client.GetAsync("/api/services/getServices");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetProviders_ShouldReturnOk()
        {
            var response = await _client.GetAsync("/api/providers/getProviders");
            response.EnsureSuccessStatusCode();
        }
    }
}
