using System.ComponentModel.DataAnnotations;
using api.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Notifications;

namespace api.ViewModels
{
    public class CreateCliente_EnderecoViewModel : Notifiable<Notification>
    {
        public int Cliente_Id { get; set; }

        public string Rua { get; set; }

        public int Rua_Nro { get; set; }

        public string Cidade { get; set; }

        public string CEP { get; set; }

        public string Bairro { get; set; }

        public string Complemento { get; set; }

       public int Endereco_Tipo_Id { get; set; }
    }
}
