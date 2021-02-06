using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Controle_de_Vendas.Models;

namespace Controle_de_Vendas.Data
{
    public class Controle_de_VendasContext : DbContext
    {
        public Controle_de_VendasContext (DbContextOptions<Controle_de_VendasContext> options)
            : base(options)
        {
        }

        public DbSet<Controle_de_Vendas.Models.Departamento> Departamento { get; set; }
    }
}
