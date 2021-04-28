using Newtonsoft.Json;
using System;

namespace BakTraCam.Common.Helper.Exceptions
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
