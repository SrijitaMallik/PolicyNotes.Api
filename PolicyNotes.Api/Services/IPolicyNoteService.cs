using PolicyNotes.Api.Models;

namespace PolicyNotes.Api.Services
{
    public interface IPolicyNoteService
    {
        Task<PolicyNote> AddNoteAsync(string policyNumber, string note);
        Task<List<PolicyNote>> GetAllAsync();
        Task<PolicyNote?> GetByIdAsync(int id);
    }
}
