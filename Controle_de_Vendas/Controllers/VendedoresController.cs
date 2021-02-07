using Controle_de_Vendas.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_de_Vendas.Controllers
{
  public class VendedoresController : Controller
  {
    private readonly ServicosVendedores servicos;

    public VendedoresController(ServicosVendedores _servicos)
    {
      servicos = _servicos;
    }

    public IActionResult Index()
    {
      var list = servicos.FindAll();

      return View(list);
    }
  }
}
