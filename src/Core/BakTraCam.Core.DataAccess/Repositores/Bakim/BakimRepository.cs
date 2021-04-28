using BakTraCam.Core.DataAccess.Context;
using BakTraCam.Core.DataAccess.Repositores.Base;
using BakTraCam.Core.DataAccess.Repositories.Base;
using BakTraCam.Core.Entity;

namespace BakTraCam.Core.DataAccess.Repositores.Bakim
{
    public sealed class BakimRepository : BaseRepository<BakimEntity>, IBakimRepository
    {
        public BakimRepository(DatabaseContext context): base(context) { }
    }
}
