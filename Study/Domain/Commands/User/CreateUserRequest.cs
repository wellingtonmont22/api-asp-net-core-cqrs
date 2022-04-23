
using Flunt.Notifications;
using Flunt.Validations;

namespace Study.Domain.Commands.User
{
    public class CreateUserRequest: Notifiable<Notification>
    {
        public string Email { get; set; }

        public string Senha { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Email, "Email", "O email não pode ser nulo ou vazio.")
                .IsEmail(Email, "Email", "O email possui caracteres inválidos.")
                .IsNotNullOrEmpty(Senha, "Senha","A senha não pode ser nulo ou vazio.")
       
                );
        }
    }
}
