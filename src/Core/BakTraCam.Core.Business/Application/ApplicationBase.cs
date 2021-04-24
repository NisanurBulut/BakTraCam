using BakTraCam.Core.DataAccess.UnitOfWork;

namespace BakTraCam.Core.Business.Application
{
    public abstract class ApplicationBase<T>
    {
     
        protected IDatabaseUnitOfWork UoW { get; }
      
        protected ApplicationBase(IDatabaseUnitOfWork uow)
        {
          
            //UoW = serviceProvider.GetService<IDatabaseUnitOfWork>();
            UoW = uow;
        }
    }
}
