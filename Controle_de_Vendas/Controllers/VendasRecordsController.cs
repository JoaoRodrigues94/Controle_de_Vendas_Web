using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_de_Vendas.Controllers
{
  public class VendasRecordsController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }    
    public IActionResult BuscaSimples()
    {
      return View();
    }  
    public IActionResult BuscaAgrupada()
    {
      return View();
    }
  }
}
