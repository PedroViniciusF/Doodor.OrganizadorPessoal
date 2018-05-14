using System;
using System.Collections.Generic;
using AutoMapper;
using Doodor.OrganizadorPessoal.Application.Interfaces;
using Doodor.OrganizadorPessoal.Application.ViewModels;
using Doodor.OrganizadorPessoal.Domain.Bus;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Commands;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Contas.Commands;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Entities;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Repositories;

namespace Doodor.OrganizadorPessoal.Application.Services
{
    public class ContaAppService : IContaAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IContaRepository _contaRepository;

        public ContaAppService(IBus bus, IMapper mapper, IContaRepository contaRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _contaRepository = contaRepository;
        }        


        public IEnumerable<ContaViewModel> ObterTodos(Guid usuarioId)
        {
            var result = _contaRepository.Find(x=>x.UsuarioId == usuarioId);
            return _mapper.Map<IEnumerable<Conta>,IEnumerable<ContaViewModel>>(result);
        }

        public ContaViewModel ObterPorId(Guid id)
        {
            var conta = _contaRepository.FindById(id);          
        
            return _mapper.Map<ContaViewModel>(conta);
        }

        public void CriarConta(ContaViewModel contaViewModel)
        {
            var objCommand = _mapper.Map<CriarContaCommand>(contaViewModel);

            _bus.SendCommand(objCommand);
        }

        public void AtualizarConta(ContaViewModel contaViewModel)
        {
            var objCommand = _mapper.Map<AtualizarContaCommand>(contaViewModel);

            _bus.SendCommand(objCommand);
        }

        public void DeletarConta(Guid contaId)
        {
            var objCommand = new DeletarContaCommand(contaId);

            _bus.SendCommand(objCommand);
        }

        public void Dispose()
        {
            _contaRepository.Dispose();
        }
    }
}
