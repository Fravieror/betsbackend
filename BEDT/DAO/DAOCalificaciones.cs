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
    public class DAOCalificaciones : DbContext
    {
        public DAOCalificaciones() : base("DAO")
        {

        }
        public DbSet<calificaciones> calificaciones { get; set; }
        public DbSet<modulo> modulo { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
        public List<calificaciones> ObtenerCalificaciones(string Id_curso = null, string Id_modulo = null, string Id_usuario = null)
        {
            using (var x = new BEDT.DAO.DAOCalificaciones())
            {
                var listaModulos = x.modulo.ToList();
                var listaUsuarios = x.usuarios.ToList();

                int idCurso = 0;
                int idModulo = 0;
                int idUsuario = 0;
                int.TryParse(Id_curso, out idCurso);
                int.TryParse(Id_modulo, out idModulo);
                int.TryParse(Id_usuario, out idUsuario);


                
                var listaCalificaciones = x.calificaciones.Where(y => y.Id_curso == (idCurso == 0 ? y.Id_curso : idCurso))
                                       .Where(y => y.Id_modulo == (idModulo == 0 ? y.Id_modulo : idModulo))
                                       .Where(y => y.Id_usuario == (idUsuario == 0 ? y.Id_usuario : idUsuario))
                                       .ToList();

                listaCalificaciones = listaCalificaciones.Join(listaUsuarios, inicio => inicio.Id_usuario, final => final.Id_usuario, (inicio, final) => new calificaciones
                                                            {
                                                                Id_calificacion = inicio.Id_calificacion,
                                                                Id_curso = inicio.Id_curso,
                                                                Id_modulo = inicio.Id_modulo,
                                                                Id_usuario = inicio.Id_usuario,
                                                                Calificacion = inicio.Calificacion,
                                                                usuarios = final
                                                            }).Where(z => z.usuarios.Tipo_usuario == 2).ToList();

                return listaCalificaciones.Join(listaModulos, inicio => inicio.Id_modulo, final => final.Id_modulo, (inicio, final) => new calificaciones
                                       {
                                           Id_calificacion = inicio.Id_calificacion,
                                           Id_curso = inicio.Id_curso,
                                           Id_modulo = inicio.Id_modulo,
                                           Id_usuario = inicio.Id_usuario,
                                           Calificacion = inicio.Calificacion,
                                           usuarios = inicio.usuarios,
                                           modulo = final
                                       }).ToList();


            }
        }
        public void GuardarCalificacion(calificaciones calificacion) {
            using (var x = new BEDT.DAO.DAOCalificaciones())
            {
                if (calificacion.Id_calificacion > 0)
                {
                    x.Entry(calificacion).State = EntityState.Modified;
                }
                else {
                    x.Entry(calificacion).State = EntityState.Added;
                }
                x.SaveChanges();
            }
        }

    }
}