using BakTraCam.Core.DataAccess.Repositores;
using BakTraCam.Service.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using BakTraCam.Core.Entity;
using BakTraCam.Core.DataAccess.UnitOfWork;

namespace BakTraCam.Core.Business.Domain.Bakim
{
    public  class BakimDomain:DomainBase<BakimDomain>,IBakimDomain
    {
        private readonly IDatabaseUnitOfWork _uow;
        private readonly IBakimRepository _bakimRep;
        public BakimDomain(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _bakimRep = serviceProvider.GetService<IBakimRepository>();
            _uow = serviceProvider.GetService<IDatabaseUnitOfWork>();
        }
        public async Task<IEnumerable<BakimModel>> BakimlariGetirAsync()
        {
            return (await _bakimRep.ListAsync<BakimModel>()).OrderBy(m => m.Aciklama);
        }
        public async Task<BakimModel> KaydetBakimAsync(BakimModel model)
        {

            BakimEntity bakim = new BakimEntity();

            Mapper.Map(model, bakim);
            await _bakimRep.AddAsync(bakim);
            await _uow.SaveChangesAsync();

            return Mapper.Map<BakimEntity, BakimModel>(bakim);

        }
    }
}
