using System.Collections.Generic;

namespace Controle_de_Vendas.Models.ViewModels
{
  public class VendedoresViewModel
  {
    public Vendedor Vendedor { get; set; }
    public ICollection<Departamento> Departamentos { get; set; }
  }
}
