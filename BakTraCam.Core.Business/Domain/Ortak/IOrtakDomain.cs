using BakTraCam.Service.DataContract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BakTraCam.Core.Business.Domain
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
