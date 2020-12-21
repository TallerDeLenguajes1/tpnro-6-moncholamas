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
            if (SesionIniciada())
            {
                return RedirectToAction("index", "Home");
            }
            return View();
        }


        [HttpPost]
        public ActionResult Ingresar(LoginViewModel us)
        {
                    
            if (ModelState.IsValid)
            {
                Usuario usuario = _mapper.Map<Usuario>(us);
                var repoU = new RepositorioUsuarios();
                var UsuarioValidado = repoU.Verificar(usuario);
                if (UsuarioValidado!=null)
                {
                    IniciarSesion(UsuarioValidado);
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    return RedirectToAction("index", "Login");
                }
            }

            return RedirectToAction("index", "Login");

        }

                       
        public ActionResult Logout()
        {
            CerrarSesion();
            return RedirectToAction("index","Home");
        }

               
    }
}
