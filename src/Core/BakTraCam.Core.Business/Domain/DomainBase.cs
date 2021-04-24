using BakTraCam.Core.DataAccess.UnitOfWork;
using BakTraCam.Util.Mapping.Adapter;

namespace BakTraCam.Core.Business.Domain
{
    public abstract class DomainBase<T>
    {
      
        protected ICustomMapper Mapper;

        //private readonly IDatabaseUnitOfWork _uow;
        // protected IDatabaseUnitOfWork UoW;
        public IDatabaseUnitOfWork Uow { get; }

        protected DomainBase(ICustomMapper mapper,IDatabaseUnitOfWork uow)
        {
            //Mapper = serviceProvider.GetService<ICustomMapper>();
            // UoW = serviceProvider.GetService<IDatabaseUnitOfWork>();
            Mapper = mapper;
            Uow = uow;
        }

        
    }
}
