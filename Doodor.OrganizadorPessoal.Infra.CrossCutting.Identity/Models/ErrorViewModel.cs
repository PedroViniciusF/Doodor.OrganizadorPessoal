using System;

namespace Doodor.OrganizadorPessoal.Infra.CrossCutting.Identity
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}