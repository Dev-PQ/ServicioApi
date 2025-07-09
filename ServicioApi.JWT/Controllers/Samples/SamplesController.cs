using LibreriaBSNetCore.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServicioApi.BusinessObjects.Consulta;
using ServicioApi.BusinessObjects.Consultas;
using ServicioApi.Facade.Samples;

namespace ServicioApi.JWT.Controllers.Samples
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Asegura que este controlador requiere autenticación
    public class SamplesController : ControllerBase
    {
        [Route("Client_Factura")]
        [HttpPost()]
        public virtual byte[] Client_Factura(Peticion peticio)
        {
            try
            {
                SamplesFacade faSamplesFacade = new SamplesFacade();
                return faSamplesFacade.Client_Factura(peticio.whereJobHeader);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw;
            }
        }

        [Route("GetFlotas_Seguro")]
        [HttpPost()]
        public virtual IList<Flotas> GetFlotas_Seguro(Peticion peticion)
        {
            try
            {
                SamplesFacade faSamplesFacade = new SamplesFacade();
                return faSamplesFacade.GetFlotas_Seguro(peticion.whereGroups, peticion.whereJobHeader);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw;
            }
        }

        [Route("Equipo")]
        [HttpPost()]
        public virtual IList<Equipos> Equipo(Peticion peticion)
        {
            try
            {
                SamplesFacade faSamplesFacade = new SamplesFacade();
                return faSamplesFacade.Equipo(peticion.whereGroups);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw;
            }
        }

        [Route("ComponentesPorEquipo")]
        [HttpPost()]
        public virtual IList<Componentes> ComponentesPorEquipo(Peticion peticion)
        {
            try
            {
                SamplesFacade faSamplesFacade = new SamplesFacade();
                return faSamplesFacade.ComponentesPorEquipo(peticion.whereGroups, peticion.whereJobHeader);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw;
            }
        }
        [Route("NivelServicio")]
        [HttpPost()]
        public virtual IList<Nivelservicio> NivelServicio(Peticion peticion)
        {
            try
            {
                SamplesFacade faSamplesFacade = new SamplesFacade();
                return faSamplesFacade.NivelServicio(peticion.whereGroups);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw;
            }
        }

        [Route("AceiteLubricante")]
        [HttpGet()]
        public virtual IList<Aceitelubricante> AceiteLubricante()
        {
            try
            {
                SamplesFacade faSamplesFacade = new SamplesFacade();
                return faSamplesFacade.AceiteLubricante();
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw;
            }
        }
    }
}
