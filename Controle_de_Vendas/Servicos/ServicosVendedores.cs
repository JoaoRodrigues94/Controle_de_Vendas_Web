using Controle_de_Vendas.Data;
using Controle_de_Vendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Controle_de_Vendas.Servicos.Exceptions;

namespace Controle_de_Vendas.Servicos
{
  public class ServicosVendedores
  {
    private readonly Controle_de_VendasContext DB;

    public ServicosVendedores(Controle_de_VendasContext context)
    {
      DB = context;
    }

    public async Task<List<Vendedor>> FindAllAsync()
    {
      return await DB.Vendedores.ToListAsync();
    }

    public async Task InsertAsync(Vendedor obj)
    {
      DB.Add(obj);
      await DB.SaveChangesAsync();
    }

    public async Task<Vendedor> FindByIdAsync(int id)
    {
      return await DB.Vendedores.Include(x => x.Departamento).FirstOrDefaultAsync(x => x.VendedorID == id);
    }

    public async Task RemoveAsync(int id)
    {
      var r = await DB.Vendedores.FindAsync(id);
      DB.Vendedores.Remove(r);
      await DB.SaveChangesAsync();
    }

    public async Task UpdateAsync(Vendedor obj)
    {
      bool verifica = await DB.Vendedores.AnyAsync(x => x.VendedorID == obj.VendedorID);
      if (!verifica)
      {
        throw new NotFoundException("ID Não Encontrado!");
      }
      try
      {
        DB.Update(obj);
        await DB.SaveChangesAsync();
      }
      catch(DbUpdateConcurrencyException ex)
      {
        throw new DbConcurrencyException(ex.Message);
      }
    }
  }
}
