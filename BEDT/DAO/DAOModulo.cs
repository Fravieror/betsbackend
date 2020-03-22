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
    public class DAOModulo : DbContext
    {
        public DAOModulo() : base("DAO")
        {

        }
        public DbSet<modulo> Modulo { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<calificaciones> calificaciones { get; set; }
        public void GuardarModulo(modulo modulo)
        {
            using (var x = new BEDT.DAO.DAOModulo())
            {
                var listaEstudiantes = x.usuarios.Where(a => a.Tipo_usuario == 2).ToList();
                if (modulo.Id_modulo > 0)
                {
                    x.Entry(modulo).State = EntityState.Modified;
                }
                else
                {                    
                    x.Entry(modulo).State = EntityState.Added;
                    foreach (var estudiante in listaEstudiantes)
                    {
                        calificaciones calificaciones = new calificaciones
                        {
                            Id_curso = modulo.Id_curso,
                            Id_modulo = modulo.Id_modulo,
                            Id_usuario = estudiante.Id_usuario
                        };
                        x.Entry(calificaciones).State = EntityState.Added;
                    }
                }
                x.SaveChanges();
            }
        }
        public List<modulo> ObtenerModulo(string id_Curso = null)
        {
            int id_CursoNumero = 0;
            int.TryParse(id_Curso, out id_CursoNumero);
            using (var x = new BEDT.DAO.DAOModulo())
            {
                return x.Modulo.Where(a => a.Id_curso == (id_CursoNumero == 0 ? a.Id_curso : id_CursoNumero)).ToList();
            }
        }
    }
}