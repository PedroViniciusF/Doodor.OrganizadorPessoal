using Doodor.OrganizadorPessoal.Domain.Financeiro.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Doodor.OrganizadorPessoal.Controllers
{
    [Produces("application/json")]
    [Route("api/Conta")]
    public class ContaController : BaseController
    {
        
        
        //[HttpPost]
        //public async Task<IActionResult> PostConta([FromBody]dynamic body)
        //{
        //    try
        //    {
        //        var contaCommand = new CriarContaCommand
        //        {
        //            DataPgto = body.DataPgto,
        //            DiaVencimento = body.DiaVencimento,
        //            Nome = body.Nome,
        //            Pago = body.Pago,
        //            Parcelado = body.Parcelado,
        //            QtdParcelas = body.QtdParcelas,
        //            ValorTotal = body.ValorTotal
        //        };

        //        var result = ContaHandler.Handle(contaCommand);

        //        return CreateResponse(result);
        //    }
        //    catch (Exception e)
        //    {
        //        return CreateResponse(null, e.Message);
        //    }            
        //}
    }
}