using System.Collections.Generic;
using System.Threading.Tasks;
using BakTraCam.Service.DataContract;

namespace BakTraCam.Core.Business.Application.Kullanici
{
    public interface IKullaniciApplication
    {
        Task<IEnumerable<KullaniciModel>> KullaniciListesiGetirAsync();
        Task<KullaniciModel> KaydetKullaniciAsync(KullaniciModel kullaniciModel);
        Task<int> SilKullaniciAsync(int id);
        Task<KullaniciModel> KullaniciGetirAsync(int id);
    }
}
