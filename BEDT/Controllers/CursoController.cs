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
    public class CursoController : ApiController
    {
        public JsonResult<List<curso>> Get(string id_usuario = null)
        {
            BEDT.DAO.DAOCurso contexto = new BEDT.DAO.DAOCurso();
            var listaCurso = contexto.ObtenerCurso(id_usuario);
            return Json(listaCurso);
        }
        [HttpPost]
        public JsonResult<Respuesta> Post([FromBody]curso curso)
        {
            try
            {
                BEDT.DAO.DAOCurso contexto = new BEDT.DAO.DAOCurso();
                contexto.GuardarCurso(curso);
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
    }
}