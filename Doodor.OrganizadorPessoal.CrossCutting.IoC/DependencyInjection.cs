using AutoMapper;
using Doodor.OrganizadorPessoal.Application.Interfaces;
using Doodor.OrganizadorPessoal.Application.Services;
using Doodor.OrganizadorPessoal.CrossCutting.Bus;
using Doodor.OrganizadorPessoal.Domain.Authentication.Commands;
using Doodor.OrganizadorPessoal.Domain.Authentication.Events;
using Doodor.OrganizadorPessoal.Domain.Authentication.Repository;
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
using Doodor.OrganizadorPessoal.Repo.SqlServer.Repository;
using Doodor.OrganizadorPessoal.Repo.SqlServer.Uow;
using Doodor.OrganizadorPessoal.Repository.Repositories;
using Doodor.OrganizadorPessoal.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Doodor.OrganizadorPessoal.CrossCutting
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInjectionDependencies(this IServiceCollection services)
        {
            //ASPNET 
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Services
            services.AddTransient<IEmailService, EmailService>();

            //Application 
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IContaAppService, ContaAppService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();

            //Domain -  Commands
            services.AddScoped<IHandler<CriarContaCommand>, ContaHandler>();
            services.AddScoped<IHandler<AtualizarContaCommand>, ContaHandler>();
            services.AddScoped<IHandler<DeletarContaCommand>, ContaHandler>();
            services.AddScoped<IHandler<RegistrarUsuarioCommand>, UsuarioHandler>();

            //Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<ContaCriadaEvent>, ContaEventHandler>();
            services.AddScoped<IHandler<ContaAtualizadaEvent>, ContaEventHandler>();
            services.AddScoped<IHandler<ContaDeletadaEvent>, ContaEventHandler>();
            services.AddScoped<IHandler<UsuarioRegistradoEvent>, UsuarioEventHandler>();

            //Infra
            services.AddScoped<IContaRepository, ContaRepository> ();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ContasContext>();
            services.AddScoped<IBus, InMemoryBus>();            

            return services;
        }
    }
}
