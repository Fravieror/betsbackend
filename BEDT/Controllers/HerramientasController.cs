using BEDT.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace BEDT.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("")]
    public class HerramientasController : ApiController
    {
        public JsonResult<List<herramientas>> Get(int? id_Curso = null, int? id_discapacidad = null, int? id_modulo = null, int? id_usuario = null)
        {         
            BEDT.DAO.DAOHerramientas contexto = new BEDT.DAO.DAOHerramientas();
            var lista = contexto.ObtenerHerramientas(id_Curso, id_discapacidad, id_modulo, id_usuario);
            return Json(lista);
        }
        public JsonResult<string> Get(string ruta)
        {
            byte[] bytes = File.ReadAllBytes(System.Web.Hosting.HostingEnvironment.MapPath("~") + ruta);            
            return Json(Convert.ToBase64String(bytes));
        }
        public JsonResult<Respuesta> Post([FromBody]herramientas herramienta)
        {
            try
            {
                BEDT.DAO.DAOHerramientas contexto = new BEDT.DAO.DAOHerramientas();
                contexto.GuardarHerramientas(herramienta);
                if (!string.IsNullOrEmpty(herramienta.PdfBase64))
                {
                    string rutaFinal = "/Pdf/" + herramienta.Id_herramienta + "_" + DateTime.Now.ToString("dd-MMMM-yyyy-HH_mm_ss") + ".pdf";
                    string rutaPDF = System.Web.Hosting.HostingEnvironment.MapPath("~") + rutaFinal;
                    File.WriteAllBytes(rutaPDF, Convert.FromBase64String(herramienta.PdfBase64));
                    herramienta.RutaPDF = rutaFinal;
                }
                if (!string.IsNullOrEmpty(herramienta.VideoBase64)) {
                    string rutaFinal = "/Video/" + herramienta.Id_herramienta + "_" + DateTime.Now.ToString("dd-MMMM-yyyy-HH_mm_ss") + ".mp4";
                    string rutaVideo = System.Web.Hosting.HostingEnvironment.MapPath("~") + rutaFinal;
                    File.WriteAllBytes(rutaVideo, Convert.FromBase64String(herramienta.VideoBase64));
                    herramienta.RutaVideo = rutaFinal;
                }
                contexto.GuardarHerramientas(herramienta);
                return Json(new Respuesta
                {
                    esCorrecta = true                   
                });
            }
            catch (Exception ex )
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