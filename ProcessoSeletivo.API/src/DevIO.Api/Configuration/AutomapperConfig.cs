using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Models;

namespace DevIO.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ContaBancaria, ContaBancariaViewModel>().ReverseMap();
            CreateMap<Banco, BancoViewModel>();
        }
    }
}