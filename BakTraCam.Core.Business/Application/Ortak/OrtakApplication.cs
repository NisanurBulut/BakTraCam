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
       
       
    }
}
