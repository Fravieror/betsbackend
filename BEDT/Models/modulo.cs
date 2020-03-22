using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BEDT.Models
{
    [Table("modulo")]
    public class modulo
    {
        [Key]
        public int Id_modulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Id_curso { get; set; }
    }
}