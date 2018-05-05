using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Doodor.OrganizadorPessoal.Application.ViewModels;
using Doodor.OrganizadorPessoal.Site.Data;
using Doodor.OrganizadorPessoal.Application.Interfaces;

namespace Doodor.OrganizadorPessoal.Site.Controllers
{
    public class ContasController : Controller
    {
        private readonly IContaAppService _contaAppService;

        public ContasController(IContaAppService contaAppService)
        {
            _contaAppService = contaAppService;
        }

        // GET: ContaViewModels
        public IActionResult Index()
        {
            try
            {
                var result = _contaAppService.ObterTodos();
                return View(result);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
        }

        // GET: ContaViewModels/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaViewModel = _contaAppService.ObterPorId(id.Value);                
            if (contaViewModel == null)
            {
                return NotFound();
            }

            return View(contaViewModel);
        }

        // GET: ContaViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContaViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContaViewModel contaViewModel)
        {
            if (ModelState.IsValid)
            {                
                _contaAppService.CriarConta(contaViewModel);
                
                return RedirectToAction(nameof(Index));
            }
            return View(contaViewModel);
        }
        
        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaViewModel = _contaAppService.ObterPorId(id);
            if (contaViewModel == null)
            {
                return NotFound();
            }
            return View(contaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, ContaViewModel contaViewModel)
        {
            if (id != contaViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contaAppService.AtualizarConta(contaViewModel);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return NotFound();
                }
                
            }
            else
            {
                return View(contaViewModel);
            }
        }
        
        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaViewModel = _contaAppService.ObterPorId(id);
            if (contaViewModel == null)
            {
                return NotFound();
            }

            return View(contaViewModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _contaAppService.DeletarConta(id);

            return RedirectToAction(nameof(Index));
        }  
    }
}
