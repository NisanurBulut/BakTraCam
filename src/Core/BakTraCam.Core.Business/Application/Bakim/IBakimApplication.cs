using System.Collections.Generic;
using System.Threading.Tasks;
using BakTraCam.Service.DataContract;

namespace BakTraCam.Core.Business.Application.Bakim
{
    public interface IBakimApplication
    {
        Task<IEnumerable<BakimModelBasic>> OnBesGunYaklasanBakimlariGetirAsync();
        Task<IEnumerable<BakimModelBasic>> BakimlistesiGetirAsync();
        Task<IEnumerable<BakimModelBasic>> GetirBakimListesiTipFiltreliAsync(int tip);
        Task<IEnumerable<BakimModelBasic>> GetirBakimListesiDurumFiltreliAsync(int durum);

        Task<BakimModel> KaydetBakimAsync(BakimModel bakimModel);
        Task<BakimModel> GetirBakimAsync(int id);
        Task<int> SilBakimAsync(int id);
    }
}
