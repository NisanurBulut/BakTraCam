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
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> OnBesGunYaklasanBakimlariGetir()
        {
            return Ok(await _bakimApp.OnBesGunYaklasanBakimlariGetirAsync());
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> KaydetBakim(BakimModel bakimModel)
        {
            var result = await _bakimApp.KaydetBakimAsync(bakimModel);
            return result != null ? Success(result) : Fail();
        }
        [Route("[action]")]
        [HttpDelete]
        public async Task<IActionResult> SilBakim(int id)
        {
            var key = await _bakimApp.SilBakimAsync(id);
            return key >0 ? Success(key) : Fail();
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetirBakim(int id)
        {
            return Ok(await _bakimApp.GetirBakimAsync(id));
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> getirBakimListesiTipFiltreli(int tip)
        {
            return Ok(await _bakimApp.getirBakimListesiTipFiltreliAsync(tip));
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> getirBakimListesiDurumFiltreli(int durum)
        {
            return Ok(await _bakimApp.getirBakimListesiDurumFiltreliAsync(durum));
        }
    }
}
