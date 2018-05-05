using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.Domain.Config
{
    public class DbSettings
    {
        public string DatabaseMongo { get; set; }
        public string UsernameMongo { get; set; }
        public string PasswordMongo { get; set; }
        public string UrlMongo { get; set; }
        public string PortMongo { get; set; }
        public string FirstDatabase { get; set; }
    }
}
