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
    public class DAODiscapacidad : DbContext
    {
        public DAODiscapacidad() : base("DAO")
        {

        }
        public DbSet<discapacidad> discapacidad { get; set; }

        public void GuardarDiscapacidad(discapacidad discapacidad)
        {
            using (var x = new BEDT.DAO.DAODiscapacidad())
            {
                if (discapacidad.Id_discapacidad > 0)
                {
                    x.Entry(discapacidad).State = EntityState.Modified;
                }
                else
                {
                    x.Entry(discapacidad).State = EntityState.Added;
                }
                x.SaveChanges();
            }
        }
        public List<discapacidad> ObtenerDiscapacidad()
        {
            using (var x = new BEDT.DAO.DAODiscapacidad())
            {
                return x.discapacidad.ToList();
            }
        }
    }
}