using PolicyNotes.Api.Models;

namespace PolicyNotes.Api.Repositories
{
    public interface IPolicyNoteRepository
    {
        Task<PolicyNote> AddAsync(PolicyNote note);
        Task<List<PolicyNote>> GetAllAsync();
        Task<PolicyNote?> GetByIdAsync(int id);
    }
}
