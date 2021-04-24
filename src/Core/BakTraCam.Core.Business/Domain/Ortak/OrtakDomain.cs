using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakTraCam.Core.Business.Domain.Kullanici;
using BakTraCam.Core.DataAccess.Repositores;
using BakTraCam.Core.DataAccess.Repositores.Duyuru;
using BakTraCam.Core.DataAccess.Repositores.Kullanici;
using BakTraCam.Core.DataAccess.UnitOfWork;
using BakTraCam.Core.Entity;
using BakTraCam.Service.DataContract;
using BakTraCam.Util.Mapping.Adapter;

namespace BakTraCam.Core.Business.Domain.Ortak
{
    public  class OrtakDomain:DomainBase<KullaniciDomain>,IOrtakDomain
    {
        //private readonly IDatabaseUnitOfWork _uow;
        private readonly IKullaniciRepository _kullaniciRep;
        private readonly IDuyuruRepository _duyuruRep;
        //public OrtakDomain(IServiceProvider serviceProvider) : base(serviceProvider)
        //{
        //    _kullaniciRep = serviceProvider.GetService<IKullaniciRepository>();
        //    _duyuruRep = serviceProvider.GetService<IDuyuruRepository>();
        //    _uow = serviceProvider.GetService<IDatabaseUnitOfWork>();
        //}
        public OrtakDomain(ICustomMapper mapper, IDatabaseUnitOfWork uow,IKullaniciRepository kullaniciRep,IDuyuruRepository duyuruRep) : base(mapper, uow)
        {
            _kullaniciRep = kullaniciRep;
            _duyuruRep = duyuruRep;
        }

        public async Task<IEnumerable<SelectModel>> KullanicilariGetirAsync()
        {
            return (await _kullaniciRep.ListAsync<SelectModel>()).OrderBy(m => m.Name);
        }
        public async Task<IEnumerable<DuyuruModel>> DuyurulariGetirAsync()
        {
            return (await _duyuruRep.ListAsync<DuyuruModel>(a=>a.Tarihi>=DateTime.Now.AddMonths(-1))).OrderBy(m => m.Id);
        }
        public async Task<DuyuruModel> KaydetDuyuruAsync(DuyuruModel model)
        {
            var duyuru = model.Id > 0 ? await _duyuruRep.FirstOrDefaultAsync(m => m.Id == model.Id) : null;
            if (null == duyuru)
            {
                duyuru = Mapper.Map<DuyuruModel, DuyuruEntity>(model);
                duyuru.Tarihi = DateTime.Now;
                await _duyuruRep.AddAsync(duyuru);
                await Uow.SaveChangesAsync();
            }
            else
            {
                Mapper.Map(model, duyuru);

                await _duyuruRep.UpdateAsync(duyuru);
                await Uow.SaveChangesAsync();
            }

            return Mapper.Map<DuyuruEntity, DuyuruModel>(duyuru);

        }

        public async Task<int> SilDuyuruAsync(int id)
        {
            await _duyuruRep.DeleteAsync(a => a.Id == id);
            await Uow.SaveChangesAsync();
            return id;
        }

        public async Task<DuyuruModel> DuyuruGetirAsync(int id)
        {
            var result = await _duyuruRep.FirstOrDefaultAsync<DuyuruModel>(a => a.Id == id);
            return result;
        }

        
    }
}
