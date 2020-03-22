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
    public class ModuloController : ApiController
    {
        public JsonResult<List<modulo>> Get(string id_curso = null)
        {
            BEDT.DAO.DAOModulo contexto = new BEDT.DAO.DAOModulo();
            var lista = contexto.ObtenerModulo(id_curso);
            return Json(lista);
        }
        public JsonResult<Respuesta> Post([FromBody]modulo modulo)
        {
            try
            {
                BEDT.DAO.DAOModulo contexto = new BEDT.DAO.DAOModulo();
                contexto.GuardarModulo(modulo);
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