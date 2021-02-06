using Controle_de_Vendas.Models.Enums;
using System;

namespace Controle_de_Vendas.Models
{
  public class Vendas
  {
    public int VendasID { get; set; }
    public DateTime Data { get; set; }
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
