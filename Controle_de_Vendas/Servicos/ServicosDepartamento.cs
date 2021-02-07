using Controle_de_Vendas.Data;
using Controle_de_Vendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_de_Vendas.Servicos
{
  public class ServicosDepartamento
  {
    private readonly Controle_de_VendasContext DB;

    public ServicosDepartamento(Controle_de_VendasContext context)
    {
      DB = context;
    }
    public List<Departamento> FindAll()
    {
      return DB.Departamento.OrderBy(x => x.Nome).ToList();
    }
  }
}
