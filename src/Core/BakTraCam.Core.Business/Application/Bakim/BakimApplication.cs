using System.Collections.Generic;
using System.Threading.Tasks;
using BakTraCam.Core.Business.Domain.Bakim;
using BakTraCam.Core.DataAccess.UnitOfWork;
using BakTraCam.Service.DataContract;

namespace BakTraCam.Core.Business.Application.Bakim
{
    public class BakimApplication : ApplicationBase<BakimApplication>, IBakimApplication
    {
        private readonly IBakimDomain _bakimDom;

        //public BakimApplication(IServiceProvider serviceProvider) : base(serviceProvider)
        //{
        //    _bakimDom = serviceProvider.GetService<IBakimDomain>();
        //}
        public BakimApplication(IDatabaseUnitOfWork uow,IBakimDomain bakimDom) : base(uow)
        {
            _bakimDom = bakimDom;
        }

        public Task<IEnumerable<BakimModelBasic>> OnBesGunYaklasanBakimlariGetirAsync()
        {
            return _bakimDom.OnBesGunYaklasanBakimlariGetirAsync();
        }
        public Task<IEnumerable<BakimModelBasic>> BakimlistesiGetirAsync()
        {
            return _bakimDom.BakimlariGetirAsync();
        }

        public Task<BakimModel> GetirBakimAsync(int id)
        {
            return _bakimDom.GetirBakimAsync(id);
        }

        public Task<IEnumerable<BakimModelBasic>> GetirBakimListesiTipFiltreliAsync(int tip)
        {
            return _bakimDom.getirBakimListesiTipFiltreliAsync(tip);
        }
        public Task<IEnumerable<BakimModelBasic>> GetirBakimListesiDurumFiltreliAsync(int durum)
        {
            return _bakimDom.getirBakimListesiDurumFiltreliAsync(durum);
        }

        public Task<BakimModel> KaydetBakimAsync(BakimModel bakimModel)
        {
            return _bakimDom.KaydetBakimAsync(bakimModel);
        }
        public Task<int> SilBakimAsync(int id)
        {
            return _bakimDom.SilBakimAsync(id);
        }

        
    }
}
