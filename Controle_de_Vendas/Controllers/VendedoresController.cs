using Controle_de_Vendas.Models;
using Controle_de_Vendas.Models.ViewModels;
using Controle_de_Vendas.Servicos;
using Controle_de_Vendas.Servicos.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    public IActionResult Delete(int? id)
    {
      if(id == null)
      {
        return RedirectToAction(nameof(Error), new { message = "ID Não Foi Fornecido!" });
      }

      var x = servicos.FindById(id.Value);
      if(x == null)
      {
        return RedirectToAction(nameof(Error), new { message = "ID Não Encontrado!" });
      }

      return View(x);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
      servicos.Remove(id);

      return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int id)
    {
      if (id == 0)
      {
        return RedirectToAction(nameof(Error), new { message = "ID Não Foi Fornecido!" });
      }

      var x = servicos.FindById(id);
      if (x == null)
      {
        return RedirectToAction(nameof(Error), new { message = "ID Não Encontrado!" });
      }

      return View(x);
    }

    public IActionResult Edit(int? id)
    {
      if (id == null)
      {
        return RedirectToAction(nameof(Error), new { message = "ID Não Foi Fornecido!" });
      }

      var x = servicos.FindById(id.Value);
      if(x == null)
      {
        return RedirectToAction(nameof(Error), new { message = "ID Não Encontrado!" });
      }

      List<Departamento> departamentos = departamento.FindAll();
      VendedoresViewModel viewModel = new VendedoresViewModel { Vendedor = x, Departamentos = departamentos };
      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Vendedor vendedor)
    {
      if(id != vendedor.VendedorID)
      {
        return RedirectToAction(nameof(Error), new { message = "ID Não Corresponde!" });
      }

      try
      {
        servicos.Update(vendedor);
        return RedirectToAction(nameof(Index));
      }
      catch(ApplicationException ex)
      {
        return RedirectToAction(nameof(Error), new { message = ex.Message });
      }
    }
    public IActionResult Error(string message)
    {
      var viewmodel = new ErrorViewModel
      {
        Message = message,
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
      };
      return View(viewmodel);
    }
  }
}
