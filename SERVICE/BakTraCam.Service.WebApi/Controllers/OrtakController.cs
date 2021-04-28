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
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> DuyuruListesiniGetir()
        {
            return Ok(await _ortakApp.DuyuruListesiGetirAsync());
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> KaydetDuyuru(DuyuruModel duyuruModel)
        {
            var result = await _ortakApp.KaydetDuyuruAsync(duyuruModel);
            return result != null ? Success(result) : Fail();
        }
        [Route("[action]")]
        [HttpDelete]
        public async Task<IActionResult> SilDuyuru(int id)
        {
            var key = await _ortakApp.SilDuyuruAsync(id);
            return key > 0 ? Success(key) : Fail();
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> DuyuruGetir(int id)
        {
            return Ok(await _ortakApp.DuyuruGetirAsync(id));
        }
    }
}
