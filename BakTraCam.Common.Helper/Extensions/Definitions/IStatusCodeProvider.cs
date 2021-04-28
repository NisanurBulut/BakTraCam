using System;
using System.Collections.Generic;
using System.Text;

namespace BakTraCam.Common.Helper.Exceptions
{
    public interface IStatusCodeProvider
    {
        int StatusCode { get; }
    }
}