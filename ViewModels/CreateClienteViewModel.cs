using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Flunt.Notifications;

namespace api.ViewModels
{
    public class CreateClienteViewModel : Notifiable<Notification>
    {

        public string? Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

    }
}
