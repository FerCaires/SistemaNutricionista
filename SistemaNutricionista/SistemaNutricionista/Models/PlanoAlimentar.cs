using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaNutricionista.Models
{
    [Table("PlanoAlimentar")]
    public class PlanoAlimentar
    {
        [Key]
        public int ID { get; set; }

        public int ClienteID { get; set; }

        [DataType(DataType.MultilineText)]
        public string Desjejum { get; set; }

        [DataType(DataType.MultilineText)]
        public string Colacao { get; set; }

        [DataType(DataType.MultilineText)]
        public string Almoco { get; set; }

        [DataType(DataType.MultilineText)]
        public string LancheTarde { get; set; }

        [DataType(DataType.MultilineText)]
        public string LancheTardeDois { get; set; }

        [DataType(DataType.MultilineText)]
        public string Jantar { get; set; }

        [DataType(DataType.MultilineText)]
        public string Ceia { get; set; }

        [DataType(DataType.MultilineText)]
        public string CeiaDois { get; set; }


        public DateTime DataRegistro { get; set; }

    }
}