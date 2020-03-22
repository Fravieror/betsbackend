using BEDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace BEDT.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("")]
    public class CalificacionesController : ApiController
    {
        // GET: api/Calificaciones
        public JsonResult<List<calificaciones>> Get(string Id_curso = null, string Id_modulo = null, string Id_usuario = null)
        {
            BEDT.DAO.DAOCalificaciones contexto = new BEDT.DAO.DAOCalificaciones();
            var listaCalificaciones = contexto.ObtenerCalificaciones(Id_curso, Id_modulo, Id_usuario);            
            return Json(listaCalificaciones);
        }

        // GET: api/Calificaciones/5
        public JsonResult<calificaciones> Get(int id)
        {
            BEDT.DAO.DAOCalificaciones contexto = new BEDT.DAO.DAOCalificaciones();
            var listaCalificaciones = contexto.ObtenerCalificaciones();           
            return Json(listaCalificaciones.FirstOrDefault());
        }

        // POST: api/Calificaciones
        public JsonResult<Respuesta> Post([FromBody]calificaciones calificaciones)
        {
            try
            {
                BEDT.DAO.DAOCalificaciones contexto = new BEDT.DAO.DAOCalificaciones();
                contexto.GuardarCalificacion(calificaciones);
                return Json(new Respuesta
                {
                    esCorrecta = true
                }); 
            }
            catch (Exception ex)
            {
                return Json(new Respuesta
                {
                    esCorrecta = false,
                    Observaciones = ex.Message
                });
            }                      
        }

        // PUT: api/Calificaciones/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Calificaciones/5
        public void Delete(int id)
        {
        }
    }
}
