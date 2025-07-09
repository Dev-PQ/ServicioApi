using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServicioApi.Facade.Browses;
using LibreriaBSNetCore.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace ServicioApi.JWT.Controllers.Browses
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrowsesController : ControllerBase
    {
        [Route("CheckSecurityOverride/{userLogin}")]
        [HttpGet()]
        public virtual byte[] CheckSecurityOverride(String userLogin)
        {
            try
            {
                BrowsesFacade faBrowsesFacade = new BrowsesFacade();
                return faBrowsesFacade.CheckSecurityOverride(userLogin);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw;
            }
        }

        [Route("SqlGroupFilter/{userLogin}")]
        [HttpGet()]
        public virtual byte[] SqlGroupFilter(String userLogin)
        {
            try
            {
                BrowsesFacade faBrowsesFacade = new BrowsesFacade();
                return faBrowsesFacade.SqlGroupFilter(userLogin);
            }
            catch (System.Exception e)
            {
                Logger.Fatal(e);
                throw;
            }
        }
    }
}
