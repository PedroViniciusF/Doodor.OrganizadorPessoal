using AutoMapper;
using Doodor.OrganizadorPessoal.Application.ViewModels;
using Doodor.OrganizadorPessoal.Domain.Authentication.Commands;
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
            CreateMap<ContaViewModel, CriarContaCommand>()                
                .ConstructUsing(c => new CriarContaCommand(c.Id, c.Nome, c.ValorTotal, c.QtdParcelas, c.DataPrimeiroPgto, c.FrequenciaDiaPgto, c.PorcVariacaoMensal, c.UsuarioId));

            CreateMap<ContaViewModel, AtualizarContaCommand>()
               .ConstructUsing(c => new AtualizarContaCommand(c.Id, c.Nome, c.ValorTotal, c.QtdParcelas, c.DataPrimeiroPgto, c.FrequenciaDiaPgto, c.PorcVariacaoMensal, c.UsuarioId));

            CreateMap<UsuarioViewModel, RegistrarUsuarioCommand>()
            .ConstructUsing(c => new RegistrarUsuarioCommand(c.Id, c.CPF, c.Nome, c.Email));
        }
    }
}
