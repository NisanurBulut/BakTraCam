using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakTraCam.Core.Business.Application;
using BakTraCam.Core.DataAccess.Repositores;
using BakTraCam.Service.DataContract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
namespace BakTraCam.Service.WebApi.Controllers
{
    public class OrtakController : BaseController<OrtakController>
    {
        private IOrtakApplication _ortakApp;
        public OrtakController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _ortakApp = serviceProvider.GetService<IOrtakApplication>();

        }
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> KullaniciListesiniGetir()
        {
            return Ok(await _ortakApp.KullaniciListesiGetirAsync());
        }
        
    }
}
