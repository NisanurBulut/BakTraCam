using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;


namespace BakTraCam.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        public BaseController(IServiceProvider serviceProvider)
        {
         
        }

        public string Kullanici => (HttpContext.User.Identity as WindowsIdentity).Name;

      
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
