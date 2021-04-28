using System.Threading.Tasks;
using BakTraCam.Core.Business.Application.Bakim;
using BakTraCam.Service.DataContract;
using Microsoft.AspNetCore.Mvc;

namespace BakTraCam.Service.WebApi.Controllers
{
    public class BakimController : BaseController<BakimController>
    {
        private readonly IBakimApplication _bakimApp;

        public BakimController(IBakimApplication bakimApp)
        {
            _bakimApp = bakimApp;
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
        public async Task<IActionResult> GetirBakimListesiTipFiltreli(int tip)
        {
            return Ok(await _bakimApp.GetirBakimListesiTipFiltreliAsync(tip));
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetirBakimListesiDurumFiltreli(int durum)
        {
            return Ok(await _bakimApp.GetirBakimListesiDurumFiltreliAsync(durum));
        }

        
    }
}
