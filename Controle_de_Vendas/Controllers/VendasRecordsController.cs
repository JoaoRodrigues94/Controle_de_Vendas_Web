using Controle_de_Vendas.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_de_Vendas.Controllers
{
  public class VendasRecordsController : Controller
  {
    private readonly VendasRecordsServices vendasRecords;

    public VendasRecordsController(VendasRecordsServices vendasRecords)
    {
      this.vendasRecords = vendasRecords;
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
    public IActionResult BuscaAgrupada()
    {
      return View();
    }
  }
}
