using System.Collections.Generic;
using System.Threading.Tasks;
using BakTraCam.Core.Business.Domain.Kullanici;
using BakTraCam.Core.DataAccess.UnitOfWork;
using BakTraCam.Service.DataContract;

namespace BakTraCam.Core.Business.Application.Kullanici
{
    public class KullaniciApplication : ApplicationBase<KullaniciApplication>, IKullaniciApplication
    {
        private readonly IKullaniciDomain _kullaniciDom;
        //private readonly IDatabaseUnitOfWork _uow ;
        //public KullaniciApplication(IServiceProvider serviceProvider) : base()
        //{
        //    _kullaniciDom = serviceProvider.GetService<IKullaniciDomain>();
        //    _uow = serviceProvider.GetService<IDatabaseUnitOfWork>();
        //}
        public KullaniciApplication(IDatabaseUnitOfWork uow, IKullaniciDomain kullaniciDom)
            : base(uow)
        {
            _kullaniciDom = kullaniciDom;
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
