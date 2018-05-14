using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Doodor.OrganizadorPessoal.Domain.Financeiro.Authentication.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        Guid GetUserId();
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
