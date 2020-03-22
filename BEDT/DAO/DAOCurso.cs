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
    public class DAOCurso : DbContext
    {
        public DAOCurso() : base("DAO")
        {

        }
        public DbSet<curso> curso { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
        public void GuardarCurso(curso curso)
        {
            using (var x = new BEDT.DAO.DAOCurso())
            {
                if (curso.Id_curso > 0)
                {
                    x.Entry(curso).State = EntityState.Modified;
                }
                else
                {
                    x.Entry(curso).State = EntityState.Added;
                }
                x.SaveChanges();
            }
        }
        /// <summary>
        /// Obtiene todos los cursos
        /// </summary>
        /// <returns></returns>
        public List<curso> ObtenerCurso(string id_usuario = null)
        {
            using (var x = new BEDT.DAO.DAOCurso())
            {
                int idUsuario = 0;
                int idCurso = 0;
                int.TryParse(id_usuario, out idUsuario);
                var usuario = x.usuarios.Where(a => a.Id_usuario == idUsuario).FirstOrDefault();
                idCurso = usuario == null ? 0 : usuario.Id_curso;
                return x.curso.Where(a => a.Id_curso == (idUsuario == 0 ? a.Id_curso : idCurso)).ToList();
            }
        }
    }
}