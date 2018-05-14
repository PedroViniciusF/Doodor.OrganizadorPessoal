using Doodor.OrganizadorPessoal.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Doodor.OrganizadorPessoal.Application.Interfaces
{
    public interface IContaAppService : IDisposable
    {        
        ContaViewModel ObterPorId(Guid id);
        IEnumerable<ContaViewModel> ObterTodos(Guid usuarioId);
        void CriarConta(ContaViewModel contaViewModel);
        void AtualizarConta(ContaViewModel contaViewModel);
        void DeletarConta(Guid contaId);
    }
}
