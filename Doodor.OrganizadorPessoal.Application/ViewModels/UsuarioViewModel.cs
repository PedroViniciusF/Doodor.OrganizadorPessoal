using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Doodor.OrganizadorPessoal.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(Guid id)
        {
            Id = new Guid();
            Id = id;
        }
        public Guid Id { get; private set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }                
    }
}
