using Controle_de_Vendas.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Controle_de_Vendas.Models
{
  public class Vendas
  {
    public int VendasID { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime Data { get; set; }
    [DisplayFormat(DataFormatString = "{0:F2}")]
    public double Qtde { get; set; }
    public StatusVendas Status { get; set; }
    public Vendedor Vendedor { get; set; }

    public Vendas()
    {
    }
    public Vendas(int vendasID, DateTime data, double qtde, StatusVendas status, Vendedor vendedor)
    {
      VendasID = vendasID;
      Data = data;
      Qtde = qtde;
      Status = status;
      Vendedor = vendedor;
    }
  }
}
