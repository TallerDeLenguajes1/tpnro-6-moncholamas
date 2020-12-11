using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using System.Data.SQLite;
using Cadeteria.Entidades;
using Cadeteria.Models;
using Microsoft.AspNetCore.Http;
using Cadeteria.Logueo;
using AutoMapper;
using Cadeteria.VIewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            if (SesionIniciada())
            {
                var repoCli = new RepositorioClientes();
                var repoCad = new RepositorioCadetes();
                var repoPed = new RepositorioPedidos();

                var listCli = repoCli.getAll();
                var listCad = repoCad.getAll();
                var listPed = repoPed.getAll();

                var listCliVM = _mapper.Map<List<Cliente>,List<ClienteViewModel>>(listCli);
                var listCadVM = _mapper.Map<List<Cadete>, List<CadeteViewModel>>(listCad);
                var listPedVM = _mapper.Map<List<Pedido>, List<PedidoViewModel>>(listPed);

                var Model = new HomeAdminViewModel {
                    Nombre = HttpContext.Session.GetString("Nombre"),
                    ultimosClientes = listCliVM,
                    pedidosPendientes = listPedVM,
                    cadetesSinPedido = listCadVM
                };
                              
                return View(Model);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
