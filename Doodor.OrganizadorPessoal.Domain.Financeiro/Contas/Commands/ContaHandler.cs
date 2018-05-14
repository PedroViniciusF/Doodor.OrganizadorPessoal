using Doodor.OrganizadorPessoal.Domain.Bus;
using Doodor.OrganizadorPessoal.Domain.Commands;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Commands;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Contas.Commands;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Contas.Events;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Entities;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Repositories;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Services;
using Doodor.OrganizadorPessoal.Domain.Handlers;
using Doodor.OrganizadorPessoal.Domain.Notifications;
using Doodor.OrganizadorPessoal.Domain.Repository;


namespace Doodor.OrganizadorPessoal.Domain.Financeiro.CommandHandlers
{
    public class ContaHandler : CommandHandler,        
        IHandler<CriarContaCommand>,
        IHandler<AtualizarContaCommand>,
        IHandler<DeletarContaCommand>
    {

        private readonly IContaRepository _contaRepository;
        private readonly IEmailService _emailService;
        private readonly IBus _bus;               

        public ContaHandler(IContaRepository contaRepository, 
                            IEmailService emailService,
                            IUnitOfWork uow, 
                            IBus bus, 
                            IDomainNotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _contaRepository = contaRepository;
            _emailService = emailService;
            _bus = bus;
        }

        public void Handle(CriarContaCommand command)
        {
            #region Fail fast Validations
            ////Fail fast validations 
            //command.Validate();
            //if (command.Invalid)
            //{                
            //    NotificarValidacoesErro()
            //}
            #endregion

            #region Validacoes de negócio
            // Verificar se nome conta ja esta cadastrada
            if (_contaRepository.NomeContaExiste(command.Nome))
                command.AddNotification("Nome", "Nome da conta já cadastrado no banco");

            if (command.Invalid)
            {
                NotificarValidacoesErro(command.Notifications);
                return;
            }                    

            //TODO: verificar se o Cliente que está alterando, é o dono da conta
            #endregion

            #region Validacoes de dominio                  

            //gerar os VOs
            //rellacionamentos
            //caso exista VOs com validações, deve-se lembrar de agrega-los a entidade e suas validações as do handler
            //como os VOs de conta foram criados para "separar" as responsabilidades de conta e a conta é a raiz de agregação das mesmas,
            ////deixei as validações da mesma toda na entidade
            var conta = new Conta(
                command.Nome, 
                command.ValorTotal, 
                command.QtdParcelas, 
                command.DiaVencimento,
                command.UsuarioId
            );

            //Aplicar as validacoes
            command.AddNotifications(conta);

            //Checar validacoes
            if (command.Invalid)
            {
                NotificarValidacoesErro(command.Notifications);
                return;
            }
            #endregion

            #region Acoes handle
            //Salvar informacoes
            _contaRepository.CriarConta(conta);

            //Enviar e-mail de conta cadastrada
            _emailService.Enviar("Desenvolvedor", "pedro.vferreira@outlook.com", "Conta Cadastrada", "Conta cadastrada com sucesso");

            if (Commit())
            {
                //Dispara evento de processo concluido
                _bus.RaiseEvent(new ContaCriadaEvent(conta.Id, conta.Nome, conta.ValorTotal, conta.Pago, conta.QtdParcelas, conta.DataProxPgto, conta.Parcelado, conta.DiaVencimento));
            }
            #endregion                        
        }
        public void Handle(AtualizarContaCommand command)
        {
            #region Validacoes de negócio
            // Verificar se conta cadastrada
            if (_contaRepository.FindById(command.Id) == null)
                command.AddNotification("Conta", "Conta não existente no banco");

            if (command.Invalid)
            {
                NotificarValidacoesErro(command.Notifications);
                return;
            }


            //TODO: verificar se o Cliente que está alterando, é o dono da conta
            #endregion

            #region Validacoes de dominio                  

            //gerar os VOs
            //rellacionamentos
            //caso exista VOs com validações, deve-se lembrar de agrega-los a entidade e suas validações as do handler
            //como os VOs de conta foram criados para "separar" as responsabilidades de conta e a conta é a raiz de agregação das mesmas,
            ////deixei as validações da mesma toda na entidade
            var conta = Conta.ContaFactory.NovaContaCompleta(
                command.Id,
                command.Nome,
                command.ValorTotal,
                command.QtdParcelas,
                command.DiaVencimento,
                command.UsuarioId
            );

            //Aplicar as validacoes
            command.AddNotifications(conta);

            //Checar validacoes
            if (command.Invalid)
            {
                NotificarValidacoesErro(command.Notifications);
                return;
            }
            #endregion

            #region Acoes handle
            //Salvar informacoes           
            _contaRepository.DeletarParcelasConta(conta.Id);
            _contaRepository.AtualizarConta(conta);

            //Enviar e-mail de conta cadastrada
            _emailService.Enviar("Desenvolvedor", "pedro.vferreira@outlook.com", "Conta Atualizada", "Conta Atuaizada com sucesso");

            if (Commit())
            {
                //Dispara evento de processo concluido
                _bus.RaiseEvent(new ContaAtualizadaEvent(conta.Id, conta.Nome, conta.ValorTotal, conta.Pago, conta.QtdParcelas, conta.DataProxPgto, conta.Parcelado, conta.DiaVencimento));
            }
            #endregion                        
        }

        public void Handle(DeletarContaCommand command)
        {
            var contaDeletar = _contaRepository.FindById(command.Id);
            // Verificar se conta cadastrada
            if (contaDeletar == null)
                command.AddNotification("Conta", "Conta não existente no banco");

            if (command.Invalid)
            {
                NotificarValidacoesErro(command.Notifications);
                return;
            }

            _contaRepository.DeletarConta(contaDeletar.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new ContaDeletadaEvent(contaDeletar.Id, contaDeletar.Nome));
            }
        }
    }
}

