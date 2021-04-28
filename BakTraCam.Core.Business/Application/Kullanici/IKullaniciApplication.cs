using BakTraCam.Service.DataContract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BakTraCam.Core.Business.Application
{
    public interface IKullaniciApplication
    {
        Task<IEnumerable<KullaniciModel>> KullaniciListesiGetirAsync();
        Task<KullaniciModel> KaydetKullaniciAsync(KullaniciModel kullaniciModel);
        Task<int> SilKullaniciAsync(int id);
        Task<KullaniciModel> KullaniciGetirAsync(int id);
    }
}
