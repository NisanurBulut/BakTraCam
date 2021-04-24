using System.Threading.Tasks;
using BakTraCam.Core.Business.Application.Kullanici;
using BakTraCam.Service.DataContract;
using Microsoft.AspNetCore.Mvc;

namespace BakTraCam.Service.WebApi.Controllers
{
    public class KullaniciController : BaseController<KullaniciController>
    {
        private readonly IKullaniciApplication _kullaniciApp;
        public KullaniciController(IKullaniciApplication kullaniciApp) 
        {
            _kullaniciApp = kullaniciApp;

        }
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> KullaniciListesiniGetir()
        {
            return Ok(await _kullaniciApp.KullaniciListesiGetirAsync());
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> KaydetKullanici(KullaniciModel kullaniciModel)
        {
            var result = await _kullaniciApp.KaydetKullaniciAsync(kullaniciModel);
            return result != null ? Success(result) : Fail();
        }
        [Route("[action]")]
        [HttpDelete]
        public async Task<IActionResult> SilKullanici(int id)
        {
            var key = await _kullaniciApp.SilKullaniciAsync(id);
            return key > 0 ? Success(key) : Fail();
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> KullaniciGetir(int id)
        {
            return Ok(await _kullaniciApp.KullaniciGetirAsync(id));
        }
    }
}
