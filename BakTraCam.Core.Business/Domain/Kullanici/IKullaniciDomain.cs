using BakTraCam.Service.DataContract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BakTraCam.Core.Business.Domain
{
    public interface IKullaniciDomain
    {
        Task<IEnumerable<KullaniciModel>> KullanicilariGetirAsync();
        Task<KullaniciModel> KaydetKullaniciAsync(KullaniciModel model);
        Task<int> SilKullaniciAsync(int id);
    }
}
