using BEDT.Models;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BEDT.DAO
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DAOHerramientas : DbContext
    {
        public DAOHerramientas() : base("DAO")
        {

        }
        public DbSet<herramientas> herrramientas { get; set; }
        public DbSet<curso> curso { get; set; }
        public DbSet<usuarios> usuarios { get; set; }

        public void GuardarHerramientas(herramientas herramientas)
        {
            using (var x = new BEDT.DAO.DAOHerramientas())
            {
                if (herramientas.Id_herramienta > 0)
                {
                    x.Entry(herramientas).State = EntityState.Modified;
                }
                else
                {
                    x.Entry(herramientas).State = EntityState.Added;
                }
                x.SaveChanges();
            }
        }
        public List<herramientas> ObtenerHerramientas(int? id_Curso = null, int? id_discapacidad = null, int? id_modulo = null, int? id_usuario = null)
        {
            using (var x = new BEDT.DAO.DAOHerramientas())
            {
                var cursos = x.curso.ToList();
                var usuario = x.usuarios.Where(a => a.Id_usuario == (id_usuario ?? a.Id_usuario)).FirstOrDefault();
                var herramientas = x.herrramientas.Where(a => a.Id_Curso == (id_Curso ?? a.Id_Curso))
                                      .Where(a => a.Id_discapacidad == (id_discapacidad ?? a.Id_discapacidad))
                                      .Where(a => a.Id_modulo == (id_modulo ?? a.Id_modulo))
                                      .Where(a => a.Id_discapacidad == (id_usuario == null ? a.Id_discapacidad : usuario.Id_discapacidad))
                                      .ToList();
                return herramientas.Join(cursos, inicio => inicio.Id_Curso, final => final.Id_curso, (inicio, final) => new herramientas
                {
                    Id_herramienta = inicio.Id_herramienta,
                    Id_Curso = inicio.Id_Curso,
                    curso = final,
                    Descripcion = inicio.Descripcion,
                    Id_discapacidad = inicio.Id_discapacidad,
                    Id_modulo = inicio.Id_modulo,
                    Nombre = inicio.Nombre,
                    RutaPDF = inicio.RutaPDF,
                    RutaVideo = inicio.RutaVideo
                }).ToList();
            }
        }
        
    }
}