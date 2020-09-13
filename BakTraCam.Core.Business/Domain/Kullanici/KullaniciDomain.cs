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
    public  class KullaniciDomain:DomainBase<KullaniciDomain>,IKullaniciDomain
    {
        private readonly IDatabaseUnitOfWork _uow;
        private readonly IKullaniciRepository _kullaniciRep;
        public KullaniciDomain(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _kullaniciRep = serviceProvider.GetService<IKullaniciRepository>();
            _uow = serviceProvider.GetService<IDatabaseUnitOfWork>();
        }
        public async Task<IEnumerable<KullaniciModel>> KullanicilariGetirAsync()
        {
            return (await _kullaniciRep.ListAsync<KullaniciModel>()).OrderBy(m => m.Ad);
        }
        public async Task<KullaniciModel> KaydetKullaniciAsync(KullaniciModel model)
        {

            KullaniciEntity Kullanici = new KullaniciEntity();

            Mapper.Map(model, Kullanici);
            await _kullaniciRep.AddAsync(Kullanici);
            await _uow.SaveChangesAsync();

            return Mapper.Map<KullaniciEntity, KullaniciModel>(Kullanici);

        }

        public async Task<int> SilKullaniciAsync(int id)
        {
            await _kullaniciRep.DeleteAsync(a => a.Id == id);
            await _uow.SaveChangesAsync();
            return id;
        }
    }
}
