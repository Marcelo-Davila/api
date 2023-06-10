using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace api.Models
{
    public class Endereco_Tipo
    {
        public int Id { get; set; }
        
        [MaxLength(100)]
        [Required]
        public string Descricao { get; set; }
    }
}