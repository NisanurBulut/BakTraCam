using BakTraCam.Core.DataAccess.Context;
using BakTraCam.Core.DataAccess.Repositores.Base;
using BakTraCam.Core.DataAccess.Repositories.Base;
using BakTraCam.Core.Entity;

namespace BakTraCam.Core.DataAccess.Repositores.Kullanici
{
    public sealed class KullaniciRepository : BaseRepository<KullaniciEntity>, IKullaniciRepository
    {
        public KullaniciRepository(DatabaseContext context): base(context) { }
    }
}
