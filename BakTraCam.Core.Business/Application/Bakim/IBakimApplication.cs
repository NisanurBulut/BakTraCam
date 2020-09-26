using BakTraCam.Service.DataContract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BakTraCam.Core.Business.Application
{
    public interface IBakimApplication
    {
        Task<IEnumerable<BakimModelBasic>> OnBesGunYaklasanBakimlariGetirAsync();
        Task<IEnumerable<BakimModelBasic>> BakimlistesiGetirAsync();
        Task<IEnumerable<BakimModelBasic>> getirBakimListesiTipFiltreliAsync(int tip);
        Task<IEnumerable<BakimModelBasic>> getirBakimListesiDurumFiltreliAsync(int durum);

        Task<BakimModel> KaydetBakimAsync(BakimModel bakimModel);
        Task<BakimModel> GetirBakimAsync(int id);
        Task<int> SilBakimAsync(int id);
    }
}
