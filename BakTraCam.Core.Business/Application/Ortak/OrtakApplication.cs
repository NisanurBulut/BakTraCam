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
    public class OrtakApplication : ApplicationBase<OrtakApplication>, IOrtakApplication
    {
        private readonly IOrtakDomain _ortakDom;
        private readonly IDatabaseUnitOfWork _uow ;
        public OrtakApplication(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _ortakDom = serviceProvider.GetService<IOrtakDomain>();
            _uow = serviceProvider.GetService<IDatabaseUnitOfWork>();
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
