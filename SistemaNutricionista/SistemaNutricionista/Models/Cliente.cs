using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaNutricionista.Models
{
    [Table("Clientes")]
    public class Cliente
    {
       
        public int ID { get; set; }
        public string Nome { get; set; }
        public int  Idade { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public virtual ClienteMedidas Medidas { get; set; }
    }
}