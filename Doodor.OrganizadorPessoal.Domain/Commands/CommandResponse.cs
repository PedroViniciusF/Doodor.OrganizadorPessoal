﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.Domain.Commands
{
    public class CommandResponse
    {
        public static CommandResponse Ok = new CommandResponse { Success = true };
        public static CommandResponse Fail = new CommandResponse { Success = false };

        public CommandResponse(bool success = false)
        {
            Success = success;
        }

        public bool Success { get; set; }    
    }
}
