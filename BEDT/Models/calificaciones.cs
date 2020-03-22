using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BEDT.Models
{
    [Table("calificaciones")]
    public class calificaciones
    {
        public int Calificacion { get; set; }
        [Key]
        public int Id_calificacion { get; set; }
        public int Id_curso { get; set; }
        public int Id_modulo { get; set; }
        public int Id_usuario { get; set; }
        [NotMapped]
        public virtual usuarios usuarios { get; set; }
        [NotMapped]
        public virtual modulo modulo { get; set; }
    }
}