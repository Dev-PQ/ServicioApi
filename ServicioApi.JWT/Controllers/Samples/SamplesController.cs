using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ServicioApi.Facade.Samples;
using LibreriaBSNetCore.Exceptions;
using ServicioApi.BusinessObjects.Consulta;

namespace ServicioApi.JWT.Controllers.Samples
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Asegura que este controlador requiere autenticación
    public class SamplesController : ControllerBase
    {
        [Route("Client_Factura/{whereJobHeader}")]
        [HttpGet()]
        public virtual byte[] Client_Factura(String whereJobHeader)
        {
            try
            {
                SamplesFacade faSamplesFacade = new SamplesFacade();
                return faSamplesFacade.Client_Factura(whereJobHeader);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw;
            }
        }

        [Route("GetFlotas_Seguro/{whereGroups}/{whereJobHeader}")]
        [HttpGet()]
        public virtual IList<Flotas> GetFlotas_Seguro(String whereGroups, String whereJobHeader)
        {
            try
            {
                SamplesFacade faSamplesFacade = new SamplesFacade();
                return faSamplesFacade.GetFlotas_Seguro(whereGroups, whereJobHeader);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw;
            }
        }

        [Route("Equipo/{whereGroups}")]
        [HttpGet()]
        public virtual IList<Equipos> Equipo(String whereGroups)
        {
            try
            {
                SamplesFacade faSamplesFacade = new SamplesFacade();
                return faSamplesFacade.Equipo(whereGroups);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw;
            }
        }

        [Route("ComponentesPorEquipo/{Group}/{Equipos}")]
        [HttpGet()]
        public virtual IList<Componentes> ComponentesPorEquipo(String Group, String Equipos)
        {
            try
            {
                SamplesFacade faSamplesFacade = new SamplesFacade();
                return faSamplesFacade.ComponentesPorEquipo(Group, Equipos);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw;
            }
        }
        [Route("NivelServicio/{whereCustomer}")]
        [HttpGet()]
        public virtual IList<Nivelservicio> NivelServicio(String whereCustomer)
        {
            try
            {
                SamplesFacade faSamplesFacade = new SamplesFacade();
                return faSamplesFacade.NivelServicio(whereCustomer);
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
