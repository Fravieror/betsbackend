using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BEDT.Models
{
    [Table("discapacidad")]
    public class discapacidad
    {
        [Key]
        public int Id_discapacidad { get; set; }
        public string Nombre { get; set; }
    }
}