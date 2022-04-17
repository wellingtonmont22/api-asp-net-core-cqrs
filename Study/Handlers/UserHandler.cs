using Study.Commands.User;

namespace Study.Handlers
{
    public class UserHandler
    {
        public CreateUserResponse Handler(CreateUserRequest request)
        {


            return new CreateUserResponse
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Senha = request.Senha,
            };
        }
    }
}
