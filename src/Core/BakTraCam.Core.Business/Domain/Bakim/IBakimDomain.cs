using System.Collections.Generic;
using System.Threading.Tasks;
using BakTraCam.Service.DataContract;

namespace BakTraCam.Core.Business.Domain.Bakim
{
    public interface IBakimDomain
    {
        Task<IEnumerable<BakimModelBasic>> OnBesGunYaklasanBakimlariGetirAsync();
        Task<IEnumerable<BakimModelBasic>> BakimlariGetirAsync();
        Task<IEnumerable<BakimModelBasic>> getirBakimListesiTipFiltreliAsync(int tip);
        Task<IEnumerable<BakimModelBasic>> getirBakimListesiDurumFiltreliAsync(int durum);

        Task<BakimModel> KaydetBakimAsync(BakimModel model);
        Task<int> SilBakimAsync(int id);
        Task<BakimModel> GetirBakimAsync(int id);
    }
}
