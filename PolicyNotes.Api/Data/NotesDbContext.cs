using Microsoft.EntityFrameworkCore;
using PolicyNotes.Api.Models;

namespace PolicyNotes.Api.Data
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) { }

        public DbSet<PolicyNote> PolicyNotes { get; set; } = null!;
    }
}
