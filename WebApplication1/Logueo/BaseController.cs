using Cadeteria.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Logueo
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            
        }

        //metodos para la sesion

        internal void IniciarSesion(Usuario us) {
            HttpContext.Session.SetString("Nombre",us.Nombre);
            HttpContext.Session.SetInt32("Rol", us.Rol);
            //acomodar la BD para tener roles numerados
            //HttpContext.Session.SetInt32("Rol", us.Id);
        }

        internal bool SesionIniciada()
        {
            return (HttpContext.Session.GetString("Nombre") != null);
            
        }
        internal void CerrarSesion()
        {
            HttpContext.Session.Remove("Nombre");
        }
       
    }
}
