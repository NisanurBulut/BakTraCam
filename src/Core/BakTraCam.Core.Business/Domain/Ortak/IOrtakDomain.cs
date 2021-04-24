using System.Collections.Generic;
using System.Threading.Tasks;
using BakTraCam.Service.DataContract;

namespace BakTraCam.Core.Business.Domain.Ortak
{
    public interface IOrtakDomain
    {
        Task<IEnumerable<SelectModel>> KullanicilariGetirAsync();
        Task<IEnumerable<DuyuruModel>> DuyurulariGetirAsync();
        Task<DuyuruModel> KaydetDuyuruAsync(DuyuruModel model);
        Task<int> SilDuyuruAsync(int id);
        Task<DuyuruModel> DuyuruGetirAsync(int id);
    }
}
