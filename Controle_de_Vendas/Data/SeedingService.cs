using Controle_de_Vendas.Models;
using Controle_de_Vendas.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_de_Vendas.Data
{
  public class SeedingService
  {
    private Controle_de_VendasContext DB;

    public SeedingService(Controle_de_VendasContext context)
    {
      DB = context;
    }

    public void Seed()
    {
      if(DB.Departamento.Any() || DB.Vendas.Any() || DB.Vendedores.Any())
      {
        return; // DB já foi populado!
      }

      Departamento d1 = new Departamento(1, "Computadores");
      Departamento d2 = new Departamento(2, "Eletronicos");
      Departamento d3 = new Departamento(3, "Fashion");
      Departamento d4 = new Departamento(4, "Livros");

      Vendedor v1 = new Vendedor(1, "Bob", "bob@gmail.com", new DateTime(1994, 8, 21), 1000.0, d1);
      Vendedor v2 = new Vendedor(2, "Maria", "maria@gmail.com", new DateTime(1990, 7, 1), 2000.00, d2);
      Vendedor v3 = new Vendedor(3, "Alex", "alex@gmail.com", new DateTime(1994, 3, 20), 1500.0, d3);
      Vendedor v4 = new Vendedor(4, "Donal", "donal@gmail.com", new DateTime(1994, 5, 11), 1450.0, d4);
      Vendedor v5 = new Vendedor(5, "Joao", "joao@gmail.com", new DateTime(1994, 12, 21), 3000.0, d1);
      Vendedor v6 = new Vendedor(6, "Paulo", "Paulo@gmail.com", new DateTime(1994, 12, 21), 3000.0, d2);

      Vendas vd1 = new Vendas(1, new DateTime(2021, 1, 1), 11000.0, StatusVendas.Faturado, v1);
      Vendas vd2 = new Vendas(2, new DateTime(2021, 1, 1), 11000.0, StatusVendas.Faturado, v2);
      Vendas vd3 = new Vendas(3, new DateTime(2021, 1, 1), 11000.0, StatusVendas.Faturado, v3);
      Vendas vd4 = new Vendas(4, new DateTime(2021, 1, 1), 11000.0, StatusVendas.Faturado, v4);
      Vendas vd5 = new Vendas(5, new DateTime(2021, 1, 1), 11000.0, StatusVendas.Faturado, v5);
      Vendas vd6 = new Vendas(6, new DateTime(2021, 1, 1), 11000.0, StatusVendas.Faturado, v6);
      Vendas vd7 = new Vendas(7, new DateTime(2021, 1, 11), 11000.0, StatusVendas.Faturado, v1);
      Vendas vd8 = new Vendas(8, new DateTime(2021, 1, 11), 11000.0, StatusVendas.Faturado, v2);
      Vendas vd9 = new Vendas(9, new DateTime(2021, 1, 11), 11000.0, StatusVendas.Faturado, v3);
      Vendas vd10 = new Vendas(10, new DateTime(2021, 1, 11), 11000.0, StatusVendas.Faturado, v4);
      Vendas vd11 = new Vendas(11, new DateTime(2021, 1, 11), 11000.0, StatusVendas.Faturado, v5);
      Vendas vd12 = new Vendas(12, new DateTime(2021, 1, 11), 11000.0, StatusVendas.Faturado, v6);

      DB.Departamento.AddRange(d1, d2, d3, d4);
      DB.Vendedores.AddRange(v1, v2, v3, v4,v5,v6);
      DB.Vendas.AddRange(vd1, vd2, vd3, vd4,vd5,vd6, vd7,vd8,vd9,vd10,vd11,vd12);

      DB.SaveChanges();
    }
  }
}
