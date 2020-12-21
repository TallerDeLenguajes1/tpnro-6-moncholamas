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
                    IdRol = Convert.ToInt32(HttpContext.Session.GetInt32("Rol")),
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
                RepositorioCadetes ReCad = new RepositorioCadetes();
                ReCad.altaCadete(cadeteDTO);
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
            if (SesionIniciada())
            {
                RepositorioCadetes ReCad = new RepositorioCadetes();
                ReCad.borrarCadete(id);
                return RedirectToAction("index");
            }
            return RedirectToAction("index","Home");
        }

        public ActionResult ModificarCadete(int id)
        {
            //RepositorioCadetes ReCad = new RepositorioCadetes();
            //ReCad.InfoCadete(id);
            return View();
        }

        [HttpGet]
        [Route("/Cadete/AsignarVehiculo/{id}")]
        public ActionResult AsignarVehiculo(int id)
        {
            var repoCad = new RepositorioCadetes();
            var cadeteDTO = repoCad.getCadete(id);
            if (SesionIniciada()&& cadeteDTO!=null) {
                // selecciono el cadete a asignarle el Vehiculo
                
                var CadeteVM = new CadeteViewModel();
                CadeteVM = _mapper.Map<Cadete, CadeteViewModel>(cadeteDTO);

                //traigo la lista de Vehiculos
                var repoVehi = new RepositorioVehiculos();
                var listaVehiDTO = repoVehi.getAll();
                var ListaVehVM = new List<VehiculoViewModel>();
                ListaVehVM = _mapper.Map<List<Vehiculo>, List<VehiculoViewModel>>(listaVehiDTO);

                var AsigCadVM = new AsignarVehiculoCadeteViewModel()
                {
                    Nombre = CadeteVM.Nombre,
                    IdCadete = CadeteVM.IdCad,
                    ListaDeVehiculos = ListaVehVM
                };
                return View(AsigCadVM);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult CargarVehiculo(AsignarVehiculoCadeteViewModel AsigValC)
        {
            if (SesionIniciada())
            {
                if (ModelState.IsValid)
                {
                    var repoCad = new RepositorioCadetes();
                    
                    repoCad.AsignarVehiculo(AsigValC.IdCadete, AsigValC.IdVehiculo);
                    return RedirectToAction("index", "Cadetes");
                }
                
            }
            return RedirectToAction("index","Home");
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
