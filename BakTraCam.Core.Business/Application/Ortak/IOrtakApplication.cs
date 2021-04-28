using BakTraCam.Service.DataContract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BakTraCam.Core.Business.Application
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
