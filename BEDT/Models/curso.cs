using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BEDT.Models
{
    [Table("curso")]
    public class curso
    {
        [Column("Descripcion")]
        public string Descripcion { get; set; }
        [Key]
        [Column("Id_curso")]
        public int Id_curso { get; set; }
        [Column("Nombre")]
        public string Nombre { get; set; }
    }
}