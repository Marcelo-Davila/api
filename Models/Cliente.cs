using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [MaxLength(70)]
        public string? Nome { get; set; }
        
        [MaxLength(100)]
        public string Email { get; set; }
        
        [MaxLength(255)]
        public string Senha { get; set; }

        [MaxLength(255)]
        public string Senha_Criptografada { get; set; }

        public DateTime Data_Cadastro { get; set; } = DateTime.Now;
    }
}
