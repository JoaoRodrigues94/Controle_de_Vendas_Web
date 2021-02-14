using System;
using System.Linq;
using System.Collections.Generic;

namespace Controle_de_Vendas.Models
{
  public class Departamento
  {
    public int DepartamentoID { get; set; }
    public string Nome { get; set; }
    public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

    public Departamento()
    {
    }
    public Departamento(int departamentoID, string nome)
    {
      DepartamentoID = departamentoID;
      Nome = nome;
    }

    public void AddVendedor(Vendedor vendedor)
    {
      Vendedores.Add(vendedor);
    }

    public double TotalVendas(DateTime inicio, DateTime fim)
    {
      return Vendedores.Sum(vendedor => vendedor.TotalVenda(inicio, fim));
    }
  }
}
