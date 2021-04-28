using System.Collections.Generic;
using System.Threading.Tasks;
using BakTraCam.Core.Business.Domain.Ortak;
using BakTraCam.Core.DataAccess.UnitOfWork;
using BakTraCam.Service.DataContract;

namespace BakTraCam.Core.Business.Application.Ortak
{
    public class OrtakApplication : ApplicationBase<OrtakApplication>, IOrtakApplication
    {
        private readonly IOrtakDomain _ortakDom;
        //private readonly IDatabaseUnitOfWork _uow ;
        //public OrtakApplication(IServiceProvider serviceProvider) : base(serviceProvider)
        //{
        //    _ortakDom = serviceProvider.GetService<IOrtakDomain>();
        //    _uow = serviceProvider.GetService<IDatabaseUnitOfWork>();
        //}
        public OrtakApplication(IDatabaseUnitOfWork uow, IOrtakDomain ortakDom)
            : base(uow)
        {
            _ortakDom = ortakDom;
        }


        public Task<IEnumerable<SelectModel>> KullaniciListesiGetirAsync()
        {
            return _ortakDom.KullanicilariGetirAsync();
        }

        public Task<IEnumerable<DuyuruModel>> DuyuruListesiGetirAsync()
        {
            return _ortakDom.DuyurulariGetirAsync();
        }
        public Task<DuyuruModel> KaydetDuyuruAsync(DuyuruModel duyuruModel)
        {
            return _ortakDom.KaydetDuyuruAsync(duyuruModel);
        }

        public Task<int> SilDuyuruAsync(int id)
        {
            return _ortakDom.SilDuyuruAsync(id);
        }

        public Task<DuyuruModel> DuyuruGetirAsync(int id)
        {
            return _ortakDom.DuyuruGetirAsync(id);
        }


    }
}
