using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BakTraCam.Common.Helper.Exceptions
{
    public class DefaultStatusCodeProvider : IStatusCodeProvider
    {
        public int StatusCode { get { return (int)HttpStatusCode.InternalServerError; } }
    }
}