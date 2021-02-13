using Controle_de_Vendas.Data;
using Controle_de_Vendas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_de_Vendas.Servicos
{
  public class VendasRecordsServices
  {
    private readonly Controle_de_VendasContext DB;

    public VendasRecordsServices(Controle_de_VendasContext context)
    {
      DB = context;
    }

    public async Task<List<Vendas>> FindByDateAsync(DateTime? min, DateTime? max)
    {
      var res = from obj in DB.Vendas select obj;

      if (min.HasValue)
      {
        res = res.Where(x => x.Data >= min.Value);
      }

      if (max.HasValue)
      {
        res = res.Where(x => x.Data <= max.Value);
      }
      return await res
        .Include(x => x.Vendedor)
        .Include(x => x.Vendedor.Departamento)
        .OrderByDescending(x => x.Data)
        .ToListAsync();
    }
  }
}
