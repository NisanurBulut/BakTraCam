using BakTraCam.Core.Business.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using BakTraCam.Service.DataContract;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BakTraCam.Core.DataAccess.UnitOfWork;

namespace BakTraCam.Core.Business.Application
{
    public class KullaniciApplication : ApplicationBase<KullaniciApplication>, IKullaniciApplication
    {
        private readonly IKullaniciDomain _kullaniciDom;
        private readonly IDatabaseUnitOfWork _uow ;
        public KullaniciApplication(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _kullaniciDom = serviceProvider.GetService<IKullaniciDomain>();
            _uow = serviceProvider.GetService<IDatabaseUnitOfWork>();
        }

     
        public Task<IEnumerable<KullaniciModel>> KullaniciListesiGetirAsync()
        {
            return _kullaniciDom.KullanicilariGetirAsync();
        }
        public Task<KullaniciModel> KaydetKullaniciAsync(KullaniciModel kullaniciModel)
        {
            return _kullaniciDom.KaydetKullaniciAsync(kullaniciModel);
        }

        public Task<int> SilKullaniciAsync(int id)
        {
            return _kullaniciDom.SilKullaniciAsync(id);
        }

        public Task<KullaniciModel> KullaniciGetirAsync(int id)
        {
            return _kullaniciDom.KullaniciGetirAsync(id);
        }
    }
}
