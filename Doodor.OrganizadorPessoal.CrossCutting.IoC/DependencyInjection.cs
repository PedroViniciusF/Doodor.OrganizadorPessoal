using AutoMapper;
using Doodor.OrganizadorPessoal.Application.Interfaces;
using Doodor.OrganizadorPessoal.Application.Services;
using Doodor.OrganizadorPessoal.CrossCutting.Bus;
using Doodor.OrganizadorPessoal.Domain.Bus;
using Doodor.OrganizadorPessoal.Domain.Financeiro.CommandHandlers;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Commands;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Contas.Commands;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Contas.Events;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Repositories;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Services;
using Doodor.OrganizadorPessoal.Domain.Handlers;
using Doodor.OrganizadorPessoal.Domain.Notifications;
using Doodor.OrganizadorPessoal.Domain.Repository;
using Doodor.OrganizadorPessoal.Repo.SqlServer.Context;
using Doodor.OrganizadorPessoal.Repo.SqlServer.Uow;
using Doodor.OrganizadorPessoal.Repository.Repositories;
using Doodor.OrganizadorPessoal.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Doodor.OrganizadorPessoal.CrossCutting
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInjectionDependencies(this IServiceCollection services)
        {
            //Services
            services.AddTransient<IEmailService, EmailService>();

            //Application 
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IContaAppService, ContaAppService>();
             
            //Domain -  Commands
            services.AddScoped<IHandler<CriarContaCommand>, ContaHandler>();
            services.AddScoped<IHandler<AtualizarContaCommand>, ContaHandler>();
            services.AddScoped<IHandler<DeletarContaCommand>, ContaHandler>();

            //Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<ContaCriadaEvent>, ContaEventHandler>();
            services.AddScoped<IHandler<ContaAtualizadaEvent>, ContaEventHandler>();
            services.AddScoped<IHandler<ContaDeletadaEvent>, ContaEventHandler>();

            //Infra
            services.AddScoped<IContaRepository, ContaRepository> ();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ContasContext>();
            services.AddScoped<IBus, InMemoryBus>();            

            return services;
        }
    }
}
