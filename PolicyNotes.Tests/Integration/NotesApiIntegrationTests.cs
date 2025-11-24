using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using PolicyNotes.Api.Data;
using PolicyNotes.Api.DTOs;
using PolicyNotes.Api.Models;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace PolicyNotes.Tests.Integration
{
    public class NotesApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public NotesApiIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        
        private HttpClient CreateTestClient()
        {
            var testDbName = Guid.NewGuid().ToString();

            var factory = _factory.WithWebHostBuilder(builder =>
            {
                
                builder.UseEnvironment("Testing");

                builder.ConfigureServices(services =>
                {
                    
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(DbContextOptions<NotesDbContext>));

                    if (descriptor != null)
                        services.Remove(descriptor);

                    services.AddDbContext<NotesDbContext>(options =>
                        options.UseInMemoryDatabase(testDbName));

                    var sp = services.BuildServiceProvider();
                    using var scope = sp.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<NotesDbContext>();
                    db.Database.EnsureCreated();
                });
            });

            return factory.CreateClient();
        }

        [Fact]
        public async Task PostNote_ReturnsCreated_And_GetById_ReturnsOk()
        {
            var client = CreateTestClient();

            var dto = new NoteCreateDto { PolicyNumber = "PN-INT-1", Note = "Integration test note" };
            var postResp = await client.PostAsJsonAsync("/notes", dto);

            Assert.Equal(HttpStatusCode.Created, postResp.StatusCode);
            var created = await postResp.Content.ReadFromJsonAsync<PolicyNote>();
            Assert.NotNull(created);
            Assert.Equal("PN-INT-1", created!.PolicyNumber);

            var getResp = await client.GetAsync($"/notes/{created.Id}");
            Assert.Equal(HttpStatusCode.OK, getResp.StatusCode);
        }

        [Fact]
        public async Task GetMissing_ReturnsNotFound()
        {
            var client = CreateTestClient();
            var resp = await client.GetAsync("/notes/999999");
            Assert.Equal(HttpStatusCode.NotFound, resp.StatusCode);
        }
    }
}
