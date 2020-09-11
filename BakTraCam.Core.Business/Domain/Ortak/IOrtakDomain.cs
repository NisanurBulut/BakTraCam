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
    }
}
