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
    public class LoginController : ApiController
    {
        public JsonResult<Respuesta> Post([FromBody]login login)
        {
            try
            {
                BEDT.DAO.DAOUsuarios contexto = new BEDT.DAO.DAOUsuarios();
                if (contexto.AutenticarUsuario(login))
                {
                    return Json(new Respuesta
                    {
                        esCorrecta = true,
                        Observaciones = "Usuario autenticado con exito."
                    });
                }
                else {
                    return Json(new Respuesta
                    {
                        esCorrecta = false,
                        Observaciones = "Usuario y/o clave incorrectos"
                    }); 
                }                
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