using BEDT.Models;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BEDT.DAO
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DAOUsuarios : DbContext
    {
        public DAOUsuarios() : base("DAO")
        {

        }
        public DbSet<usuarios> usuarios { get; set; }

        public Respuesta GuardarUsuarios(usuarios usuario)
        {            
            usuario.contrasena = this.GetMD5(usuario.contrasena);
            using (var x = new BEDT.DAO.DAOUsuarios())
            {
                if(ObtenerUsuarios().Exists(z => z.Email == usuario.Email))                
                {
                    if (usuario.Id_usuario > 0)
                    {
                        x.Entry(usuario).State = EntityState.Modified;
                    }
                    else {
                        return new Respuesta
                        {
                            esCorrecta = false,
                            Observaciones = "El Email ya esta registrado"                                                        
                        };
                    }                    
                }
                else
                {
                    x.Entry(usuario).State = EntityState.Added;
                }
                x.SaveChanges();
                return new Respuesta
                {
                    esCorrecta = true
                };
            }
        }
        public List<usuarios> ObtenerUsuarios()
        {            
            using (var x = new BEDT.DAO.DAOUsuarios())
            {
                return x.usuarios.ToList();
            }
        }
        public usuarios ObtenerUsuario(string email)
        {
            using (var x = new BEDT.DAO.DAOUsuarios())
            {
                var usuario = x.usuarios.Where(y => y.Email == email).SingleOrDefault() ?? new Models.usuarios();
                usuario.contrasena = null;
                return usuario;
            }
        }
        /// <summary>
        /// Autentica usuario
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public bool AutenticarUsuario(login login) {            
            using (var x = new BEDT.DAO.DAOUsuarios()) {                
                return x.ObtenerUsuarios().Exists(a => a.Email == login.Email && a.contrasena == this.GetMD5(login.Contrasena));
            }
        }       
        private string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}