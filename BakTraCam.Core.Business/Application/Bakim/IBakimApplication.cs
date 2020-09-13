using BakTraCam.Service.DataContract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BakTraCam.Core.Business.Application
{
    public interface IBakimApplication
    {
        Task<IEnumerable<BakimModelBasic>> BakimlistesiGetirAsync();
        Task<BakimModel> KaydetBakimAsync(BakimModel bakimModel);
        Task<int> SilBakimAsync(int id);
    }
}
