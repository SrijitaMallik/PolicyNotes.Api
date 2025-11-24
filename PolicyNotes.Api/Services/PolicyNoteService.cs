using PolicyNotes.Api.Models;
using PolicyNotes.Api.Repositories;

namespace PolicyNotes.Api.Services
{
    public class PolicyNoteService : IPolicyNoteService
    {
        private readonly IPolicyNoteRepository _repo;

        public PolicyNoteService(IPolicyNoteRepository repo)
        {
            _repo = repo;
        }

        public async Task<PolicyNote> AddNoteAsync(string policyNumber, string note)
        {
            if (string.IsNullOrWhiteSpace(policyNumber))
                throw new ArgumentException("Policy number is required", nameof(policyNumber));

            var entity = new PolicyNote
            {
                PolicyNumber = policyNumber,
                Note = note ?? string.Empty
            };

            return await _repo.AddAsync(entity);
        }

        public Task<List<PolicyNote>> GetAllAsync() => _repo.GetAllAsync();

        public Task<PolicyNote?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
    }
}
