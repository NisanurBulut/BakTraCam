using Microsoft.AspNetCore.Mvc;
using BakTraCam.Core.Business.Application.Bakim;


namespace BakTraCam.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        //public IBakimApplication BakimApp { get; }

        //public BaseController(IBakimApplication bakimApp)
        //{
        //    BakimApp = bakimApp;
        //}


        public OkObjectResult Success()
        {
            return Ok(new { success = true });
        }

        public OkObjectResult Success(int key)
        {
            return Ok(new { success = true, key });
        }

        public OkObjectResult Success(object data)
        {
            return Ok(new { success = true, data });
        }

        public OkObjectResult Success(string message)
        {
            return Ok(new { success = true, message });
        }

        public OkObjectResult Fail()
        {
            return Ok(new { success = false });
        }

        public OkObjectResult Fail(string message)
        {
            return Ok(new { success = false, message });
        }
    }
}
