using System;
using Newtonsoft.Json;

namespace BakTraCam.Common.Helper.Extensions.Definitions
{
    public class DefaultJsonFormatter : IJsonFormatter
    {
        private Exception _exception { get; }

        public DefaultJsonFormatter(Exception exception)
        {
            _exception = exception;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(_exception.Message);
        }

    }
}
