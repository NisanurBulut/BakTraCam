using BakTraCam.Core.DataAccess.Repositores;
using BakTraCam.Service.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BakTraCam.Core.Business.Domain.Bakim
{
    public  class BakimDomain:DomainBase<BakimDomain>,IBakimDomain
    {
        private readonly IBakimRepository _bakimRep;
        public BakimDomain(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _bakimRep = serviceProvider.GetService<IBakimRepository>();
        }
        public async Task<IEnumerable<BakimModel>> BakimlariGetirAsync()
        {
            return (await _bakimRep.ListAsync<BakimModel>()).OrderBy(m => m.Aciklama);
        }
       
    }
}
