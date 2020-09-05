using BakTraCam.Util.Mapping.Adapter;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
namespace BakTraCam.Core.Business.Domain
{
    public class DomainBase<T>
    {
      
        protected ICustomMapper Mapper;
       // protected IDatabaseUnitOfWork UoW;
     

        public DomainBase(IServiceProvider serviceProvider)
        {
          
            Mapper = serviceProvider.GetService<ICustomMapper>();
            // UoW = serviceProvider.GetService<IDatabaseUnitOfWork>();
            
        }

    }
}
