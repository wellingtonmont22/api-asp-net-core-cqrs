using Dapper;
using Study.Domain.Commands.User;
using Study.Entities;
using Study.Infra.Data;
using Study.Query;
using System.Data;

namespace Study.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _ctx;
        public UserRepository(DbContext context)
        {
            _ctx = context;
        }

        public async Task<List<QueryResult>> GetAllAsync()
        {
            string query = @"SELECT * FROM user";

            using(var conn = _ctx.Connection)
            {
                var result = (await conn.QueryAsync<QueryResult>(query)).ToList();

                return result;
            }
        }
        public async Task<QueryResult> GetAsync(int id)
        {
            string query = @"SELECT * FROM user WHERE Id=@id";

            using (var conn = _ctx.Connection)
            {
                var result = await conn.QueryFirstOrDefaultAsync<QueryResult>(query, new
                {
                    Id = id
                });

                return result;
            }
        }
        public async Task<int> CreateAsync(User user)
        {
            using(var conn = _ctx.Connection)
            {
                string query = @"INSERT INTO user(Email, Senha) VALUES (@Email, @Senha)";

                var parameters = new DynamicParameters();
                parameters.Add("@Email", user.Email, DbType.String);
                parameters.Add("@Senha", user.Senha, DbType.String);

                var result = await conn.ExecuteAsync(query, parameters);

                return result;

            }
        }

        public async Task<int> UpdateAsync(User user)
        {
            using (var conn = _ctx.Connection)
            {
                string query = @"UPDATE user SET Email=@email, Senha=@senha WHERE Id=@id";

                var parameters = new DynamicParameters();
                parameters.Add("@email", user.Email);
                parameters.Add("@senha", user.Senha);
                parameters.Add("@id", user.Id);

                var result = await conn.ExecuteAsync(sql: query,param:parameters);

                return result;

            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = _ctx.Connection)
            {
                string query = @"DELETE FROM user WHERE Id=@id";

                var result = await conn.ExecuteAsync(sql: query, param: new
                {
                    @id = id
                });

                return result;

            }
        }

    }
}
