using System.Collections.Generic;
using System.Threading.Tasks;
using BakTraCam.Service.DataContract;

namespace BakTraCam.Core.Business.Domain.Kullanici
{
    public interface IKullaniciDomain
    {
        Task<IEnumerable<KullaniciModel>> KullanicilariGetirAsync();
        Task<KullaniciModel> KaydetKullaniciAsync(KullaniciModel model);
        Task<int> SilKullaniciAsync(int id);
        Task<KullaniciModel> KullaniciGetirAsync(int id);
    }
}
