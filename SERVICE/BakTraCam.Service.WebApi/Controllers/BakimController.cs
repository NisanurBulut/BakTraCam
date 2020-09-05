using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakTraCam.Core.Business.Application;
using BakTraCam.Core.DataAccess.Repositores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
namespace BakTraCam.Service.WebApi.Controllers
{
    public class BakimController : BaseController<BakimController>
    {
        private IBakimApplication _bakimApp;
        public BakimController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _bakimApp = serviceProvider.GetService<IBakimApplication>();

        }
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> BakimListesiniGetir()
        {
            return Ok(await _bakimApp.BakimlistesiGetirAsync());
        }
    }
}
