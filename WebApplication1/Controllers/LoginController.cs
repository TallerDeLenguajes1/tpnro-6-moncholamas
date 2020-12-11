using Cadeteria.Logueo;
using Cadeteria.VIewModels;
using Cadeteria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cadeteria.Entidades;

namespace Cadeteria.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IMapper _mapper;
        public LoginController(IMapper mapper)
        {
            _mapper = mapper;
        }
        

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Ingresar(LoginViewModel us)
        {

            Usuario usuario = _mapper.Map<Usuario>(us);

            if (ModelState.IsValid)
            {
                var repoU = new RepositorioUsuarios();
                if (repoU.Verificar(usuario))
                {
                    IniciarSesion(usuario);
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    return Redirect("index");
                }
            }
            else
            {
                return Redirect("index");
            }

        }

                       
        public ActionResult Logout()
        {
            CerrarSesion();
            return RedirectToAction("index","Home");
        }

               
    }
}
