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
    public class DiscapacidadController : ApiController
    {
        public JsonResult<List<discapacidad>> Get()
        {
            BEDT.DAO.DAODiscapacidad contexto = new BEDT.DAO.DAODiscapacidad();
            var listaDiscapacidad = contexto.ObtenerDiscapacidad();
            return Json(listaDiscapacidad);
        }
        public JsonResult<Respuesta> Post([FromBody]discapacidad discapacidad)
        {
            try
            {
                BEDT.DAO.DAODiscapacidad contexto = new BEDT.DAO.DAODiscapacidad();
                contexto.GuardarDiscapacidad(discapacidad);
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
                    Observaciones = ex.Message,
                    Stack = ex.StackTrace
                });
            }
        }
    }
}