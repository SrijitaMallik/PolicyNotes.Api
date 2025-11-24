using Microsoft.EntityFrameworkCore;
using PolicyNotes.Api.Data;
using PolicyNotes.Api.Models;

namespace PolicyNotes.Api.Repositories
{
    public class PolicyNoteRepository : IPolicyNoteRepository
    {
        private readonly NotesDbContext _db;

        public PolicyNoteRepository(NotesDbContext db)
        {
            _db = db;
        }

        public async Task<PolicyNote> AddAsync(PolicyNote note)
        {
            _db.PolicyNotes.Add(note);
            await _db.SaveChangesAsync();
            return note;
        }

        public Task<List<PolicyNote>> GetAllAsync()
        {
            return _db.PolicyNotes.AsNoTracking().ToListAsync();
        }

        public Task<PolicyNote?> GetByIdAsync(int id)
        {
            return _db.PolicyNotes.AsNoTracking().FirstOrDefaultAsync(n => n.Id == id);
        }
    }
}
