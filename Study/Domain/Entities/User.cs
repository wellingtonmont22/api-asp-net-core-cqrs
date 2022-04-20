using Flunt.Notifications;
using Flunt.Validations;
using Study.Domain.Commands.User;

namespace Study.Entities
{
    public class User: Notifiable<Notification>
    {
        public int Id { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public static User Create(CreateUserRequest request)
        {
            var user = new User() { 
                Email = request.Email,
                Senha = request.Senha,
            };

            user.Validate();

            return user;
        }

        public static User Update(UpdateUserRequest request)
        {
            var user = new User()
            {
                Id = request.Id,
                Email = request.Email,
                Senha=request.Senha,
            };

            user.Validate();

            return user;

        }

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterOrEqualsThan(Email, 10, "Email")
                .IsLowerOrEqualsThan(Email, 255, "Email")
                .IsGreaterOrEqualsThan(Senha, 8, "Senha")
                .IsLowerOrEqualsThan(Senha, 255, "Senha")
                .IsNotNullOrEmpty(Id.ToString(), "Id")

             );
        }
    }
}
