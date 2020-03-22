using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BEDT.Models
{
    [Table("usuarios")]
    public class usuarios
    {
        [Key]
        public int Id_usuario { get; set; }
        public string T_Doc { get; set; }
        public int N_Doc { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime F_Nacimiento { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public string Celular { get; set; }
        public string Genero { get; set; }
        public int Tipo_usuario { get; set; }
        public int Id_discapacidad { get; set; }
        public string contrasena { get; set; }
        public int Id_curso { get; set; }

    }
}