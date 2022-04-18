using FluentValidation.Results;
using Study.Commands.User;
using Study.Commands.User.Validators;
using Study.Entities;
using Study.Infra.Repositories;

namespace Study.Handlers
{
    public class UserHandler
    {
        //public UserRepository _repository { get; private set; }
        //public UserHandler(UserRepository repository)
        //{
        //    _repository = repository;
        //}
        public async Task<dynamic> HandlerAsync(CreateUserRequest request)
        {
            UserValidator validator = new UserValidator();
            ValidationResult result = validator.Validate(request);
            if (result.IsValid)
            {
                User user = new User()
                {
                    Email = request.Email,
                    Senha = request.Senha,
                };

                //var created = await _repository.Create(user);

                return new CreateUserResponse
                {
                    Id = 1,
                    Email = request.Email,
                    Senha = request.Senha,
                };
            }
            else
            {
                return result.Errors;
            }
            
        }
    }
}
