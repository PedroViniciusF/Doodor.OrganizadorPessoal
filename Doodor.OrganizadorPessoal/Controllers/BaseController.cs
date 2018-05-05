using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Doodor.OrganizadorPessoal.Domain.Commands;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Commands;
using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doodor.OrganizadorPessoal.Controllers
{
    [Produces("application/json")]
    [Route("api/Base")]
    public class BaseController : Controller
    {       
        //public IActionResult CreateResponse(CommandResult commandResult)
        //{
        //    if (commandResult.Errors.Count > 0)
        //    {
        //        return BadRequest(new { statusCode = 400 , message = commandResult.Message, errors = commandResult.Errors });                                
        //    }
  

        //    return Ok(new { statusCode = 200, message = commandResult.Message, body = string.Empty });
        //}

        //public IActionResult CreateResponse(object result, string errorMessage)
        //{
        //    if (errorMessage.Length > 0)
        //    {
        //        return BadRequest(new { statusCode = 400, message = "Busca com problema :( segue erros com mais detalhes", errors = errorMessage });
        //    }


        //    return Ok(new { statusCode = 200, message = "Busca Realizada com Sucesso", body = result });
        //}
    }
}