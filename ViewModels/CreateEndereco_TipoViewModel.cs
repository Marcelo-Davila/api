using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;

namespace api.ViewModels
{
    public class CreateEndereco_TipoViewModel : Notifiable<Notification>
    {
        [Required]
        public string Descricao { get; set; }
    }
}
