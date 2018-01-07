using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteUnpaper.Models
{
    public class Contato
    {
        public Contato()
        {

        }

        public string Nome {
            get;
            set;
        }


        public string Telefone {
            get;
            set;
        }


        public string Assunto {
            get;
            set;
        }


        public string Email {
            get;
            set;
        }

        public bool Cliente {
            get;
            set;
        }
    }
}