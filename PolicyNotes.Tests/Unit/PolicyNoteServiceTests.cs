using Microsoft.EntityFrameworkCore;
using PolicyNotes.Api.Data;
using PolicyNotes.Api.Repositories;
using PolicyNotes.Api.Services;
using Xunit;

namespace PolicyNotes.Tests.Unit
{
    public class PolicyNoteServiceTests
    {
        private PolicyNoteService BuildServiceWithInMemory(string dbName)
        {
            var options = new DbContextOptionsBuilder<NotesDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            var db = new NotesDbContext(options);
            var repo = new PolicyNoteRepository(db);
            return new PolicyNoteService(repo);
        }

        [Fact]
        public async Task AddNoteAsync_CreatesNote()
        {
            var svc = BuildServiceWithInMemory("unit_AddNote");
            var result = await svc.AddNoteAsync("PN-U1", "unit note");

            Assert.NotNull(result);
            Assert.Equal("PN-U1", result.PolicyNumber);
            Assert.Equal("unit note", result.Note);
            Assert.True(result.Id > 0);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAll()
        {
            var svc = BuildServiceWithInMemory("unit_GetAll");
            await svc.AddNoteAsync("PN-A", "a");
            await svc.AddNoteAsync("PN-B", "b");

            var list = await svc.GetAllAsync();
            Assert.Equal(2, list.Count);
        }
    }
}
