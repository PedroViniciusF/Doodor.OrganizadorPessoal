using AutoMapper;
using Doodor.OrganizadorPessoal.Application.ViewModels;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Commands;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Contas.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //CreateMap<ContaViewModel, ParcelasContaViewModel>();
            //CreateMap<ContaViewModel, PgtoContaViewModel>();

            CreateMap<ContaViewModel, CriarContaCommand>()                
                .ConstructUsing(c => new CriarContaCommand(c.Id, c.Nome, c.ValorTotal, c.QtdParcelas, c.DiaVencimento));

            CreateMap<ContaViewModel, AtualizarContaCommand>()
               .ConstructUsing(c => new AtualizarContaCommand(c.Id, c.Nome, c.ValorTotal, c.QtdParcelas, c.DiaVencimento));
        }
    }
}
