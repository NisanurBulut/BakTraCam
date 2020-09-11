using BakTraCam.Core.DataAccess.Repositores;
using BakTraCam.Service.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using BakTraCam.Core.Entity;
using BakTraCam.Core.DataAccess.UnitOfWork;

namespace BakTraCam.Core.Business.Domain.Kullanici
{
    public  class OrtakDomain:DomainBase<KullaniciDomain>,IOrtakDomain
    {
        private readonly IDatabaseUnitOfWork _uow;
        private readonly IKullaniciRepository _kullaniciRep;
        public OrtakDomain(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _kullaniciRep = serviceProvider.GetService<IKullaniciRepository>();
            _uow = serviceProvider.GetService<IDatabaseUnitOfWork>();
        }
        public async Task<IEnumerable<SelectModel>> KullanicilariGetirAsync()
        {
            return (await _kullaniciRep.ListAsync<SelectModel>()).OrderBy(m => m.Name);
        }
    }
}
