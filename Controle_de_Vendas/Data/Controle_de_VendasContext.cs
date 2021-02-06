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

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Vendas> Vendas { get; set; }
    }
}
