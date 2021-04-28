using AgileObjects.AgileMapper;
using BakTraCam.Util.Mapping.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace BakTraCam.Util.Mapping.Adapter
{
    public class CustomMapper : ICustomMapper
    {
        public CustomMapper()
        {
            Mapper.WhenMapping
                .UseConfigurations
                .From<CustomMapperConfiguration>();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map(source).ToANew<TDestination>();
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return Mapper.Map(source).Over(destination);
        }
    }
}
