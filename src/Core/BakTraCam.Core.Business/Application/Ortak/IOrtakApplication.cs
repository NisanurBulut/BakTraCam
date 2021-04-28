using System.Collections.Generic;
using System.Threading.Tasks;
using BakTraCam.Service.DataContract;

namespace BakTraCam.Core.Business.Application.Ortak
{
    public interface IOrtakApplication
    {
        Task<IEnumerable<SelectModel>> KullaniciListesiGetirAsync();
        Task<IEnumerable<DuyuruModel>> DuyuruListesiGetirAsync();
        Task<DuyuruModel> KaydetDuyuruAsync(DuyuruModel model);
        Task<int> SilDuyuruAsync(int id);
        Task<DuyuruModel> DuyuruGetirAsync(int id);
    }
}
