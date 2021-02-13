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

    public List<Vendedor> FindAll()
    {
      return DB.Vendedores.ToList();
    }

    public void Insert(Vendedor obj)
    {
      DB.Add(obj);
      DB.SaveChanges();
    }

    public Vendedor FindById(int id)
    {
      return DB.Vendedores.Include(x => x.Departamento).FirstOrDefault(x => x.VendedorID == id);
    }

    public void Remove(int id)
    {
      var r = DB.Vendedores.Find(id);
      DB.Vendedores.Remove(r);
      DB.SaveChanges();
    }

    public void Update(Vendedor obj)
    {
      if(!DB.Vendedores.Any(x => x.VendedorID == obj.VendedorID))
      {
        throw new NotFoundException("ID Não Encontrado!");
      }
      try
      {
        DB.Update(obj);
        DB.SaveChanges();
      }
      catch(DbUpdateConcurrencyException ex)
      {
        throw new DbConcurrencyException(ex.Message);
      }
    }
  }
}
