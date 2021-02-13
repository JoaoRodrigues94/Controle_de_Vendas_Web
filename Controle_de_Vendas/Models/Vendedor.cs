using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Controle_de_Vendas.Models
{
  public class Vendedor
  {
    public int VendedorID { get; set; }
    public string Nome { get; set; }
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Display(Name = "Data de Nascimento")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime Aniversario { get; set; }
    [Display(Name = "Salário Base")]
    [DisplayFormat(DataFormatString = "{0:F2}")]
    public double SalarioBase { get; set; }
    public Departamento Departamento { get; set; }
    public int DepartamentoID { get; set; }
    public ICollection<Vendas> Vendas { get; set; } = new List<Vendas>();

    public Vendedor()
    {
    }
    public Vendedor(int vendedorID, string nome, string email, DateTime aniversario, double salarioBase, Departamento departamento)
    {
      VendedorID = vendedorID;
      Nome = nome;
      Email = email;
      Aniversario = aniversario;
      SalarioBase = salarioBase;
      Departamento = departamento;
    }

    public void AddVenda(Vendas venda)
    {
      Vendas.Add(venda);
    }

    public void RemoveVenda(Vendas venda)
    {
      Vendas.Remove(venda);
    }

    public double TotalVenda(DateTime inicio, DateTime fim)
    {
      return Vendas.Where(x => x.Data >= inicio && x.Data <= fim).Sum(p => p.Qtde);
    }
  } 
}
