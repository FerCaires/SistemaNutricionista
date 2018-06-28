using SistemaNutricionista.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaNutricionista.DataContext
{
    public class SNDataContext : DbContext
    {
        public DbSet<Cliente> daoCliente { get; set; }
        public DbSet<ClienteMedidas> daoMedidas { get; set; }
    }
}