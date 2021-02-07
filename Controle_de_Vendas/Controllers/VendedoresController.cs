using Controle_de_Vendas.Models;
using Controle_de_Vendas.Models.ViewModels;
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
    private readonly ServicosDepartamento departamento;

    public VendedoresController(ServicosVendedores _servicos, ServicosDepartamento _departamento)
    {
      servicos = _servicos;
      departamento = _departamento;
    }

    public IActionResult Index()
    {
      var list = servicos.FindAll();

      return View(list);
    }

    public  IActionResult Create()
    {
      var departament = departamento.FindAll();
      var viewModel = new VendedoresViewModel { Departamentos = departament };

      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Vendedor vendedor)
    {
      servicos.Insert(vendedor);
      return RedirectToAction(nameof(Index));
    }
  }
}
