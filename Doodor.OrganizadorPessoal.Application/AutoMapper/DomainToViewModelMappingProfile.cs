using AutoMapper;
using Doodor.OrganizadorPessoal.Application.ViewModels;
using Doodor.OrganizadorPessoal.Domain.Authentication;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Entities;

namespace Doodor.OrganizadorPessoal.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Conta, ContaViewModel>()
                .ForMember(dest=>dest.QtdParcelas, opt=>opt.MapFrom(c=>c.Parcelas.Count));            
            CreateMap<Parcela, ParcelaViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
