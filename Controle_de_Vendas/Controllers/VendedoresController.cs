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

    public async Task<IActionResult> Index()
    {
      var list = await servicos.FindAllAsync();

      return View(list);
    }

    public async Task<IActionResult> Create()
    {
      var departament = await departamento.FindAllAsync();
      var viewModel = new VendedoresViewModel { Departamentos = departament };

      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Vendedor vendedor)
    {
      if (!ModelState.IsValid)
      {
        var _departamento = await departamento.FindAllAsync();
        var viewModel = new VendedoresViewModel { Vendedor = vendedor, Departamentos = _departamento };
        return View(viewModel);
      }

      await servicos.InsertAsync(vendedor);
      return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
      if(id == null)
      {
        return RedirectToAction(nameof(Error), new { message = "ID Não Foi Fornecido!" });
      }

      var x = await servicos.FindByIdAsync(id.Value);
      if(x == null)
      {
        return RedirectToAction(nameof(Error), new { message = "ID Não Encontrado!" });
      }

      return View(x);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        await servicos.RemoveAsync(id);
        return RedirectToAction(nameof(Index));
      }
      catch(IntegrityException ex)
      {
        return RedirectToAction(nameof(Error), new { message = ex.Message });
      }
    }

    public async Task<IActionResult> Details(int id)
    {
      if (id == 0)
      {
        return RedirectToAction(nameof(Error), new { message = "ID Não Foi Fornecido!" });
      }

      var x = await servicos.FindByIdAsync(id);
      if (x == null)
      {
        return RedirectToAction(nameof(Error), new { message = "ID Não Encontrado!" });
      }

      return View(x);
    }

    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return RedirectToAction(nameof(Error), new { message = "ID Não Foi Fornecido!" });
      }

      var x = await servicos.FindByIdAsync(id.Value);
      if(x == null)
      {
        return RedirectToAction(nameof(Error), new { message = "ID Não Encontrado!" });
      }

      List<Departamento> departamentos = await departamento.FindAllAsync();
      VendedoresViewModel viewModel = new VendedoresViewModel { Vendedor = x, Departamentos = departamentos };
      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Vendedor vendedor)
    {
      if (!ModelState.IsValid)
      {
        var _departamento = await departamento.FindAllAsync();
        var viewModel = new VendedoresViewModel { Vendedor = vendedor, Departamentos = _departamento };
        return View(viewModel);
      }

      if (id != vendedor.VendedorID)
      {
        return RedirectToAction(nameof(Error), new { message = "ID Não Corresponde!" });
      }

      try
      {
        await servicos.UpdateAsync(vendedor);
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
