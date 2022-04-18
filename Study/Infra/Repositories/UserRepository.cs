using Dapper;
using Study.Commands.User;
using Study.Entities;
using Study.Infra.Data;

namespace Study.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        public DbContext _ctx { get; private set; }

        public UserRepository(DbContext context)
        {
            _ctx = context;
        }
        public async Task<int> Create(User user)
        {
            using(var conn = _ctx.Connection)
            {
                string query = @"INSERT INTO user(Email, Senha) VALUES (@Email, @Senha)";

                var parameters = new DynamicParameters();
                parameters.Add("@Email", user.Email);
                parameters.Add("@Senha", user.Senha);

                var result = await conn.ExecuteAsync(query, parameters);

                return result;

            }
        }
    }
}
