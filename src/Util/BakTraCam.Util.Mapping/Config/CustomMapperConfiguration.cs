using AgileObjects.AgileMapper.Configuration;
using BakTraCam.Common.Helper.Attributes;
using BakTraCam.Core.Entity;
using BakTraCam.Service.DataContract;


namespace BakTraCam.Util.Mapping.Config
{
    internal class CustomMapperConfiguration : MapperConfiguration
    {
        protected override void Configure()
        {
            MapBakim();
            MapOrtak();
        }

        private void MapOrtak()
        {
            WhenMapping
                .From<KullaniciEntity>()
                .To<SelectModel>()
                .Map((e, dto) => e.Ad)
                .To(dto => dto.Name)
                .And
                .Map((e, dto) => e.Id)
                .To(dto => dto.Key)
                ;

            GetPlansFor<KullaniciEntity>().To<SelectModel>();
          
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