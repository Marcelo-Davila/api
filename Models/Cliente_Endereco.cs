﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace api.Models
{
    public class Cliente_Endereco
    {
        public int Id { get; set; }

        [ForeignKey("Cliente_Id")]
        public int Cliente_Id { get; set; }

        [MaxLength(100)]
        public string Rua { get; set; }

        public int Rua_Nro { get; set; }

        [MaxLength(100)]
        public string Cidade { get; set; }

        [MaxLength(8)]
        public string CEP { get; set; }

        [MaxLength(50)]
        public string Bairro { get; set; }

        [MaxLength(100)]
        public string Complemento { get; set; }

        [ForeignKey("Endereco_Tipo_Id")]
        public int Endereco_Tipo_Id { get; set; }
    }
}
