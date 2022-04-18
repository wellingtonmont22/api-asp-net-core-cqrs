using Study.Commands.User;
using Study.Entities;

namespace Study.Infra.Repositories
{
    public interface IUserRepository
    {
        public Task<int> Create(User user);
    }
}
