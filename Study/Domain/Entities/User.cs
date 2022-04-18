using Flunt.Notifications;
using Flunt.Validations;
using Study.Domain.Commands.User;

namespace Study.Entities
{
    public class User: Notifiable<Notification>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public User(CreateUserRequest request)
        {
            Email = request.Email;
            Senha = request.Senha;
        }
        public User(UpdateUserRequest request, int id)
        {
            Email = request.Email;
            Senha = request.Senha;
            Id = id;
        }

        public static User Create(CreateUserRequest request)
        {
            return new User(request);
        }

        public static User Update(UpdateUserRequest request,int id)
        {
            return new User(request, id);

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
