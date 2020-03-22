using BEDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace BEDT.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("")]
    public class UsuariosController : ApiController
    {
        // GET: api/Calificaciones
        public JsonResult<List<usuarios>> Get()
        {
            BEDT.DAO.DAOUsuarios contexto = new BEDT.DAO.DAOUsuarios();
            var listaUsuarios = contexto.ObtenerUsuarios();
            return Json(listaUsuarios);
        }
        public JsonResult<usuarios> Get(string email)
        {
            BEDT.DAO.DAOUsuarios contexto = new BEDT.DAO.DAOUsuarios();    
            
            return Json(contexto.ObtenerUsuario(email));
        }
        // POST: api/Calificaciones
        public JsonResult<Respuesta> Post([FromBody]usuarios usuario)
        {
            try
            {
                BEDT.DAO.DAOUsuarios contexto = new BEDT.DAO.DAOUsuarios();                
                return Json(contexto.GuardarUsuarios(usuario));
            }
            catch (Exception ex)
            {
                return Json(new Respuesta
                {
                    esCorrecta = false,
                    Observaciones = ex.Message,
                    Stack = ex.StackTrace
                });
            }
        }
    }
}