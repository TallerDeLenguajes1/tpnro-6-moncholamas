using AutoMapper;
using Cadeteria.Entidades;
using Cadeteria.VIewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria
{
    public class PerfilDeMapeo : Profile
    {
        public PerfilDeMapeo()
        {
            CreateMap<Cadete, CadeteViewModel>().ReverseMap();


            CreateMap<LoginViewModel, Usuario>()
                //.ForMember(x => x.Clave, opt => opt.Ignore())
                .ReverseMap();


            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Pedido, PedidoViewModel>().ReverseMap();

            CreateMap<Usuario, HomeAdminViewModel>()
                .ForMember(dest => dest.Nombre, origen => origen.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Rol, origen => origen.MapFrom(src => src.Rol));

        }       
    }
}
