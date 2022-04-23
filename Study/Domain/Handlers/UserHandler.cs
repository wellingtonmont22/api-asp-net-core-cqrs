using Study.Domain.Commands.CommandResult;
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
        public async Task<UserCommandResult> Handler(CreateUserRequest request)
        {

            request.Validate();

            if (!request.IsValid)
            {
                return UserCommandResult.IsFailure(
                    "Algum dos campos é invalido!",
                    request.Notifications
                    );
            }

            User user = User.Create(request);


            if (!user.IsValid)
            {
                return UserCommandResult.IsFailure(
                    "Algum dos campos é invalido!",
                    user.Notifications
                    );
            }

            var created = await _repository.CreateAsync(user);
            //TODO Como retornar Server Internal Erro?
            if (created != 1)
            {
                return UserCommandResult.IsFailure("Não foi possivel gravar usuário.");
            }

            return UserCommandResult.IsSuccess("Usuário criado com sucesso.", new
            {
                Email= user.Email,
                Senha= "********"
            });
        }

        public async Task<UserCommandResult> Handler(UpdateUserRequest request)
        {
            request.Validate();

            if (!request.IsValid)
            {
                return UserCommandResult.IsFailure("Algum dos campos é invalido!", request.Notifications);
            }
            var UserExists = await _repository.GetAsync(request.Id);
            if (UserExists == null)
            {
                return UserCommandResult.IsFailure("Usuário não existe!");
            }

            User user = User.Update(request);




            if (!user.IsValid)
            {
                return UserCommandResult.IsFailure("Algum dos campos é invalido!", user.Notifications);
            }

            var updated = await _repository.UpdateAsync(user);

            if (updated != 1)
            {
                //TODO Como retornar Server Internal Erro?
                return UserCommandResult.IsFailure("Não foi possivel gravar usuário.");
            }

            return UserCommandResult.IsSuccess("Usuário criado com sucesso.", new
            {
                Email= user.Email,
                Senha= "********"
            });
        }

        public async Task<dynamic> Handler(int id)
        {
            if (id == null)
            {
                return new { message = "Id não é valida." };
            }

            var result = await _repository.DeleteAsync(id);

            if (result != 1)
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
