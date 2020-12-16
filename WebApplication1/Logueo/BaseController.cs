using Cadeteria.Entidades;
using Cadeteria.Models;
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
            HttpContext.Session.SetInt32("Id", us.Id);
            HttpContext.Session.SetInt32("Rol", us.Rol);
            // si el usuario existe traigo sus datos de la BD

        
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
