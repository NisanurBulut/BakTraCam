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
        private readonly IDuyuruRepository _duyuruRep;
        public OrtakDomain(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _kullaniciRep = serviceProvider.GetService<IKullaniciRepository>();
            _duyuruRep = serviceProvider.GetService<IDuyuruRepository>();
            _uow = serviceProvider.GetService<IDatabaseUnitOfWork>();
        }
        public async Task<IEnumerable<SelectModel>> KullanicilariGetirAsync()
        {
            return (await _kullaniciRep.ListAsync<SelectModel>()).OrderBy(m => m.Name);
        }
        public async Task<IEnumerable<DuyuruModel>> DuyurulariGetirAsync()
        {
            return (await _duyuruRep.ListAsync<DuyuruModel>()).OrderBy(m => m.Id);
        }
        public async Task<DuyuruModel> KaydetDuyuruAsync(DuyuruModel model)
        {
            DuyuruEntity duyuru = model.Id > 0 ? await _duyuruRep.FirstOrDefaultAsync(m => m.Id == model.Id) : null;
            if (null == duyuru)
            {
                duyuru = Mapper.Map<DuyuruModel, DuyuruEntity>(model);

                await _duyuruRep.AddAsync(duyuru);
                await _uow.SaveChangesAsync();
            }
            else
            {
                Mapper.Map(model, duyuru);

                await _duyuruRep.UpdateAsync(duyuru);
                await _uow.SaveChangesAsync();
            }

            return Mapper.Map<DuyuruEntity, DuyuruModel>(duyuru);

        }

        public async Task<int> SilDuyuruAsync(int id)
        {
            await _duyuruRep.DeleteAsync(a => a.Id == id);
            await _uow.SaveChangesAsync();
            return id;
        }

        public async Task<DuyuruModel> DuyuruGetirAsync(int id)
        {
            var result = await _duyuruRep.FirstOrDefaultAsync<DuyuruModel>(a => a.Id == id);
            return result;
        }
    }
}
