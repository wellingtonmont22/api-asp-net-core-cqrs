using Study.Domain.Commands.User;
using Study.Entities;
using Study.Infra.Repositories;

namespace Study.Handlers
{
    public class UserHandler
    {
        private readonly IUserRepository _repository;
        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<dynamic> Handler(CreateUserRequest request)
        {
            
            request.Validate();

            if (!request.IsValid)
            {
                return request.Notifications;
            }

            User user = User.Create(request);
            

            user.Validate();

            if (!user.IsValid)
            {
                return user.Notifications;
            }

            var created = await _repository.CreateAsync(user);

            if(created != 1)
            {
                return new
                {
                    message = "Não foi possivel criar o usuário.",
                };
            }

            return new {
                    message = "Usuário criado com sucesso.",
                };
        }

        public async Task<dynamic> Handler(UpdateUserRequest request, int id)
        {
            request.Validate();

            if (!request.IsValid)
            {
                return request.Notifications;
            }
            var UserExists = await _repository.GetAsync(id);
            if (UserExists == null)
            {
                return new
                {
                    message = "Usuário não existe!"
                };
            }

            User user = User.Update(request, id);
            

            user.Validate();

            if (!user.IsValid)
            {
                return user.Notifications;
            }

            var updated = await _repository.UpdateAsync(user);

            if (updated != 1)
            {
                return new
                {
                    message = "Não foi possivel atualizar o usuário.",
                };
            }

            return new
            {
                message = "Usuário atualizado com sucesso.",
            };
        }

        public async Task<dynamic> Handler(int id)
        {
            if (id == null)
            {
                return new { message = "Id não é valida." };
            }

            var result = await _repository.DeleteAsync(id);

            if(result != 1)
            {
                return new
                {
                    message = "Usuáio não existe."
                };
            }
            return new
            {
                message = "Usuário apagado com sucesso."
            };
        }

    }
}
