using System;
using System.Collections.Generic;
using System.Text;

namespace BakTraCam.Core.Business.Application
{
    public class ApplicationBase<T>
    {
     
     //   protected IDatabaseUnitOfWork UoW { get; }
      
        public ApplicationBase(IServiceProvider serviceProvider)
        {
          
         //   UoW = serviceProvider.GetService<IDatabaseUnitOfWork>();
        }
    }
}
