using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Controle_de_Vendas.Models
{
  public class Vendedor
  {
    public int VendedorID { get; set; }
    [Required(ErrorMessage = "{0} Obrigatório!")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "{0} deve conter no minimo {2} letras e no Máximo {1}")]
    public string Nome { get; set; }
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "{0} Obrigatório!")]
    public string Email { get; set; }

    [Display(Name = "Data de Nascimento")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [Required(ErrorMessage = "{0} Obrigatório!")]
    public DateTime Aniversario { get; set; }

    [Required(ErrorMessage = "{0} Obrigatório!")]
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
