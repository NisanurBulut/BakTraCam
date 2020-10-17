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
using Microsoft.EntityFrameworkCore;
using BakTraCam.Common.Helper.Enums;

namespace BakTraCam.Core.Business.Domain.Bakim
{
    public class BakimDomain : DomainBase<BakimDomain>, IBakimDomain
    {
        private readonly IDatabaseUnitOfWork _uow;
        private readonly IBakimRepository _bakimRep;
        private readonly IKullaniciRepository _kullaniciRep;
        public BakimDomain(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _bakimRep = serviceProvider.GetService<IBakimRepository>();
            _kullaniciRep = serviceProvider.GetService<IKullaniciRepository>();
            _uow = serviceProvider.GetService<IDatabaseUnitOfWork>();
        }
        public async Task<IEnumerable<BakimModelBasic>> OnBesGunYaklasanBakimlariGetirAsync()
        {
            var query = $"SELECT  t.Id, t.Durum, t.Period, t.Tip, t.Ad, t.Aciklama, t.BaslangicTarihi,t.BitisTarihi,t.Tarihi,"
                  + " ks1.Ad as Sorumlu1, ks2.Ad as Sorumlu2, ks1.Ad as Gerceklestiren1, kg2.Ad as Gerceklestiren2,"
                  + " kg3.Ad as Gerceklestiren3, kg4.Ad as Gerceklestiren4 FROM [tBakim] as t"
                  + " left  join tKullanici ks1 on t.Sorumlu1 = ks1.Id"
                  + " left  join tKullanici ks2 on t.Sorumlu2 = ks2.Id"
                  + " left  join tKullanici kg1 on t.Gerceklestiren1 = kg1.Id"
                  + " left  join tKullanici kg2 on t.Gerceklestiren3 = kg2.Id"
                  + " left  join tKullanici kg3 on t.Gerceklestiren3 = kg3.Id"
                  + " left  join tKullanici kg4 on t.Gerceklestiren4 = kg4.Id"
                  + " where t.Durum=1 and t.Tarihi >= '" + DateTime.Now.AddDays(-15) + "'";
            var bakimlar = await _uow.RawQueryAsync<BakimModelBasic>(query, string.Empty);

            return bakimlar;
        }
        public async Task<IEnumerable<BakimModelBasic>> BakimlariGetirAsync()
        {

            var bakimlar = await _uow.RawQueryAsync<BakimModelBasic>($"SELECT  t.Id, t.Durum, t.Period, t.Tip, t.Ad, t.Aciklama, t.BaslangicTarihi,t.BitisTarihi,t.Tarihi,"
                  + " ks1.Ad as Sorumlu1, ks2.Ad as Sorumlu2, ks1.Ad as Gerceklestiren1, kg2.Ad as Gerceklestiren2,"
                  + " kg3.Ad as Gerceklestiren3, kg4.Ad as Gerceklestiren4 FROM [tBakim] as t"
                  + " left  join tKullanici ks1 on t.Sorumlu1 = ks1.Id"
                  + " left  join tKullanici ks2 on t.Sorumlu2 = ks2.Id"
                  + " left  join tKullanici kg1 on t.Gerceklestiren1 = kg1.Id"
                  + " left  join tKullanici kg2 on t.Gerceklestiren3 = kg2.Id"
                  + " left  join tKullanici kg3 on t.Gerceklestiren3 = kg3.Id"
                  + " left  join tKullanici kg4 on t.Gerceklestiren4 = kg4.Id", string.Empty);

            return bakimlar;
        }

        public async Task<BakimModel> GetirBakimAsync(int id)
        {
            BakimEntity bakim = new BakimEntity();
            BakimModel bakimModel = new BakimModel();
            bakim = await _bakimRep.FirstOrDefaultAsync(a => a.Id == id);
            return Mapper.Map<BakimEntity, BakimModel>(bakim);
        }

        public async Task<IEnumerable<BakimModelBasic>> getirBakimListesiTipFiltreliAsync(int tip)
        {
            return await _bakimRep.ListAsync<BakimModelBasic>(a => a.Tip == tip);
        }
        public async Task<IEnumerable<BakimModelBasic>> getirBakimListesiDurumFiltreliAsync(int durum)
        {
            return await _bakimRep.ListAsync<BakimModelBasic>(a => a.Durum == durum);
        }

        public async Task<BakimModel> KaydetBakimAsync(BakimModel model)
        {
            BakimEntity bakim = model.Id > 0 ? await _bakimRep.FirstOrDefaultAsync(m => m.Id == model.Id) : null;
            if (null == bakim)
            {
                // yeni bakımlar beklemede oluşur
                model.Durum = (int)Enums.BakimDurum.Beklemede;
                model.Tarihi = model.BaslangicTarihi;
                if (model.Tip == (int)Enums.BakimTip.Planli || model.Tip == (int)Enums.BakimTip.Periyodik)
                {
                    // kaç adet bakım olacağı hesaplanlanmalı ve tarihi de not alınmalı
                    TimeSpan ts = model.BitisTarihi.Subtract(model.BaslangicTarihi);
                    int dateDiff = int.Parse(ts.TotalDays.ToString());
                    int BakimSayisi = dateDiff / model.Period;
                    for (int i = 0; i < BakimSayisi; i++)
                    {
                        model.Tarihi = model.Tarihi.AddDays(model.Period);
                        bakim = Mapper.Map<BakimModel, BakimEntity>(model);

                        await _bakimRep.AddAsync(bakim);
                        await _uow.SaveChangesAsync();
                    }
                }
                else
                {
                    model.Tarihi = model.BaslangicTarihi;
                    bakim = Mapper.Map<BakimModel, BakimEntity>(model);

                    await _bakimRep.AddAsync(bakim);
                    await _uow.SaveChangesAsync();
                }

            }
            else
            {
                Mapper.Map(model, bakim);

                await _bakimRep.UpdateAsync(bakim);
                await _uow.SaveChangesAsync();
            }
            return Mapper.Map<BakimEntity, BakimModel>(bakim);

        }

        public async Task<int> SilBakimAsync(int id)
        {
            await this._bakimRep.DeleteAsync(m => m.Id == id);
            await _uow.SaveChangesAsync();
            return id;
        }
    }
}
