using Flunt.Notifications;
using Flunt.Validations;

namespace Study.Domain.Commands.User
{
    public class UpdateUserRequest: Notifiable<Notification>
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string Senha { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Id.ToString(), "Id")
                .IsNotNullOrEmpty(Email, "Email")
                .IsEmail(Email, "Email")
                .IsNotNullOrEmpty(Senha, "Senha")
                
                );
        }
    }
}
