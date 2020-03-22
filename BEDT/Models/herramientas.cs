using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BEDT.Models
{
    [Table("herramientas")]
    public class herramientas
    {
        public string Descripcion { get; set; }
        public int Id_Curso { get; set; }
        public int Id_discapacidad { get; set; }
        [Key]
        public int Id_herramienta { get; set; }
        public int Id_modulo { get; set; }
        public string Nombre { get; set; }
        public string RutaPDF { get; set; }
        public string RutaVideo { get; set; }
        [NotMapped]
        public string PdfBase64 { get; set; }
        [NotMapped]
        public string VideoBase64 { get; set; }
        [NotMapped]
        public virtual curso curso { get; set; }
    }
}