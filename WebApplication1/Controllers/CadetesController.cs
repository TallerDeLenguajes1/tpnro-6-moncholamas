using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cadeteria.Entidades;
using Cadeteria.Logueo;
using Cadeteria.Models;
using Cadeteria.VIewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cadeteria.Controllers
{
    public class CadetesController : BaseController
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
            if (SesionIniciada())
            {
                var ReCad = new RepositorioCadetes();
                List<Cadete> listaC = ReCad.getAll();
                List<CadeteViewModel> ListaCadVM = _mapper.Map<List<CadeteViewModel>>(listaC);
                var Modelo = new AdminCadeteViewModel
                {
                    NombreUsuario = HttpContext.Session.GetString("Nombre"),
                    ListaCadetes = ListaCadVM
                };
                return View(Modelo);
            }
            return View();
        }

        [HttpPost]
        public ActionResult NuevoCadete(AltaCadeteViewModel cadete)
        {
            if (ModelState.IsValid)
            {
                var cadeteDTO = _mapper.Map<AltaCadeteViewModel, Cadete>(cadete);
                var usuarioDTO = _mapper.Map<AltaCadeteViewModel,Usuario>(cadete);
                RepositorioCadetes ReCad = new RepositorioCadetes();
                ReCad.altaCadete(cadeteDTO,usuarioDTO);
                return Redirect("index");
            }
            return Redirect("Alta");
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

        public ActionResult ModificarCadete(int id)
        {
            //RepositorioCadetes ReCad = new RepositorioCadetes();
            //ReCad.InfoCadete(id);
            return View();
        }

        
        public ActionResult AsignarVehiculo()
        {
           
                return View();
            
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
