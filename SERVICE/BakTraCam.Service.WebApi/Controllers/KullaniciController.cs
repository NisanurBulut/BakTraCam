using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakTraCam.Core.Business.Application;
using BakTraCam.Service.DataContract;
using BakTraCam.Service.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BakTraCam.Service.WebApi.Controllers
{
    public class KullaniciController : BaseController<KullaniciController>
    {
        private IKullaniciApplication _kullaniciApp;
        public KullaniciController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _kullaniciApp = serviceProvider.GetService<IKullaniciApplication>();

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
            return Ok(await _kullaniciApp.KaydetKullaniciAsync(kullaniciModel));
        }
        [Route("[action]")]
        [HttpDelete]
        public async Task<IActionResult> SilKullanici(int id)
        {
            return Ok(await _kullaniciApp.SilKullaniciAsync(id));
        }
    }
}
