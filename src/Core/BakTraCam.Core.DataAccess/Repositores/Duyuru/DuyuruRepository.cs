using BakTraCam.Core.DataAccess.Context;
using BakTraCam.Core.DataAccess.Repositores.Base;
using BakTraCam.Core.DataAccess.Repositories.Base;
using BakTraCam.Core.Entity;

namespace BakTraCam.Core.DataAccess.Repositores.Duyuru
{
    public sealed class DuyuruRepository : BaseRepository<DuyuruEntity>, IDuyuruRepository
    {
        public DuyuruRepository(DatabaseContext context): base(context) { }
    }
}
