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
using Doodor.OrganizadorPessoal.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Doodor.OrganizadorPessoal.Site.Models;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Authentication.Interfaces;

namespace Doodor.OrganizadorPessoal.Site.Controllers
{
    [Authorize]
    public class ContasController : BaseController
    {
        private readonly IContaAppService _contaAppService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ContasController(IContaAppService contaAppService,
            IDomainNotificationHandler<DomainNotification> notifications,
            UserManager<ApplicationUser> userManager,
            IUser user) : base (notifications, user)
        {
            _contaAppService = contaAppService;
            _userManager = userManager;
        }
              
        public IActionResult Index()
        {
            try
            {
                var id = _userManager.GetUserId(User);                
                var result = _contaAppService.ObterTodos(Guid.Parse(id));

                if(TempData["RetornoPost"] != null)
                    ViewBag.RetornoPost = TempData["RetornoPost"].ToString();

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
            if (!ModelState.IsValid) return View(contaViewModel);

            contaViewModel.UsuarioId = UsuarioId;

            _contaAppService.CriarConta(contaViewModel);

            if (OperacaoValida())
            {
                TempData["RetornoPost"] = "success, Operação realizada com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RetornoPost = "error, Operação não realizada";
                return View(contaViewModel);
            }            
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
                    if (OperacaoValida())
                    {
                        TempData["RetornoPost"] = "success, Operação realizada com sucesso";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.RetornoPost = "error, Operação não realizada";
                        return View(contaViewModel);
                    }
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

            if (OperacaoValida())
            {
                TempData["RetornoPost"] = "success, Operação realizada com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RetornoPost = "error, Operação não realizada";
                return View(id);
            }            
        }  
    }
}
