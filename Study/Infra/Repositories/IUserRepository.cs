using Study.Domain.Commands.User;
using Study.Entities;
using Study.Query;

namespace Study.Infra.Repositories
{
    public interface IUserRepository
    {
        public Task<List<QueryResult>> GetAllAsync();
        public Task<QueryResult> GetAsync(int id);
        public Task<int> CreateAsync(User user);
        public Task<int> UpdateAsync(User user);
        
    }
}
