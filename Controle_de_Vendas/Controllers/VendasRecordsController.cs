using Controle_de_Vendas.Data;
using Controle_de_Vendas.Models;
using Controle_de_Vendas.Models.Enums;
using Controle_de_Vendas.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_de_Vendas.Controllers
{
  public class VendasRecordsController : Controller
  {
    private readonly VendasRecordsServices vendasRecords;
    private readonly Controle_de_VendasContext DB;

    public VendasRecordsController(VendasRecordsServices vendasRecords, Controle_de_VendasContext context)
    {
      this.vendasRecords = vendasRecords;
      DB = context;
    }

    public IActionResult Index()
    {
      return View();
    }    
    public async Task<IActionResult> BuscaSimples(DateTime? min, DateTime? max)
    {
      if (!min.HasValue)
      {
        min = new DateTime(DateTime.Now.Year, 1, 1);
      }
      if (!max.HasValue)
      {
        max = DateTime.Now;
      }
      ViewData["min"] = min.Value.ToString("yyyy-MM-dd");
      ViewData["max"] = max.Value.ToString("yyyy-MM-dd");
      var res = await vendasRecords.FindByDateAsync(min, max);
      return View(res);
    }
    public async  Task<IActionResult> BuscaAgrupada(DateTime? min, DateTime? max)
    {
      if (!min.HasValue)
      {
        min = new DateTime(DateTime.Now.Year, 1, 1);
      }
      if (!max.HasValue)
      {
        max = DateTime.Now;
      }
      ViewData["min"] = min.Value.ToString("yyyy-MM-dd");
      ViewData["max"] = max.Value.ToString("yyyy-MM-dd");
      var res = await vendasRecords.FindByDateGruopingAsync(min, max);
      return View(res);
    }

    public IActionResult Create()
    {
      ViewBag.Vendedores = ListaVendedor().Select(x => new SelectListItem { Text = x.Nome.ToUpper(), Value = Convert.ToString(x.VendedorID) });
      ViewBag.Departamentos = ListaDepartamentos().Select(x => new SelectListItem { Text = x.Nome.ToUpper(), Value = Convert.ToString(x.DepartamentoID) });
    
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
      Vendas dados = new Vendas
      {
        VendasID = Convert.ToInt16(collection["VendasID"]),
        Data = Convert.ToDateTime(collection["Data"]),
        Qtde = Convert.ToDouble(collection["Qtde"]),
        VendedorID = Convert.ToInt16(collection["Nome"]),
        Status = StatusVendas.Faturado
      };

      DB.Vendas.Add(dados);
      DB.SaveChanges();

      return RedirectToAction(nameof(Index));
    }
    public List<Vendedor> ListaVendedor()
    {
      var vendedor = DB.Vendedores.ToList();
      return vendedor;
    }

   public List<Departamento> ListaDepartamentos()
    {
      var departamento = DB.Departamento.ToList();
      return departamento;
    }
  }
}
