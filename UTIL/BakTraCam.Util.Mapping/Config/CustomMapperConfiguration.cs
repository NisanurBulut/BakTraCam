using AgileObjects.AgileMapper.Configuration;
using BakTraCam.Common.Helper.Attributes;
using BakTraCam.Core.Entity;
using BakTraCam.Service.DataContract;
using System;
using System.Collections.Generic;
using System.Text;


namespace BakTraCam.Util.Mapping.Config
{
    internal class CustomMapperConfiguration : MapperConfiguration
    {
        protected override void Configure()
        {
            MapBakim();
        }
        private void MapBakim()
        {
            WhenMapping
                    .From<BakimEntity>()
                    .To<BakimModel>()
                    .IgnoreTargetMembersWhere(m => m.HasAttribute<IgnoreMappingAttribute>());
            GetPlansFor<BakimEntity>().To<BakimModel>();
        }
    }
}