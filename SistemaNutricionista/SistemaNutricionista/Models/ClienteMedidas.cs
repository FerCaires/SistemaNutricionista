﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaNutricionista.Models
{
    [Table("Medidas")]
    public class ClienteMedidas
    {
        [Key]
        [ForeignKey("Cliente")]
        public int MedidasId { get; set; }

        public int Altura { get; set; }
        public decimal Peso { get; set; }
        public decimal IMC { get; set; }
        public int Cintura { get; set; }
        public int Abdomen { get; set; }
        public decimal PorcentagemGordura { get; set; }
        public decimal PorcentagemGorduraViceral { get; set; }
        public int Coxa { get; set; }

        public virtual Cliente Cliente { get; set; }


    }
}