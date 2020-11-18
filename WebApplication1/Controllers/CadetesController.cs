using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cadeteria.Entidades;
using Cadeteria.Models;
using Cadeteria.VIewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cadeteria.Controllers
{
    public class CadetesController : Controller
    {
        //Inyecto la dependencia    
        private readonly IMapper _mapper;
        public CadetesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: CadetesController
        public ActionResult Index()
        {
            RepositorioCadetes ReCad = new RepositorioCadetes();
            List<Cadete> listaC = ReCad.getAll();

          
            List<CadeteViewModel> ListaCadVM = _mapper.Map<List<CadeteViewModel>>(listaC);
            return View(ListaCadVM);
        }

        [HttpPost]
        public ActionResult NuevoCadete(Cadete cadete)
        {
            RepositorioCadetes ReCad = new RepositorioCadetes();
            ReCad.altaCadete(cadete);
            return View();
        }

        // GET: CadetesController/Alta
        public ActionResult Alta()
        {        
            return View();
        }
        public ActionResult Borrar(int id)
        {
            RepositorioCadetes ReCad = new RepositorioCadetes();
            ReCad.borrarCadete(id);
            return View();
        }

        public ActionResult Informacion(int id)
        {
            RepositorioCadetes ReCad = new RepositorioCadetes();
            ReCad.InfoCadete(id);
            return View();
        }

        // POST: CadetesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CadetesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CadetesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CadetesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CadetesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
