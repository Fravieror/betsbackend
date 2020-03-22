using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEDT.Models
{
    public class Respuesta
    {
        public bool esCorrecta { get; set; }
        public string Observaciones { get; set; }
        public string Stack { get; set; }
    }
}