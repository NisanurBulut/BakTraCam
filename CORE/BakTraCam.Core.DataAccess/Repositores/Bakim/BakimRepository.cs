using BakTraCam.Core.DataAccess.Context;
using BakTraCam.Core.DataAccess.Repositores.Base;
using BakTraCam.Core.Entity;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace BakTraCam.Core.DataAccess.Repositores.Bakim
{
    public sealed class BakimRepository : BaseRepository<BakimEntity>, IBakimRepository
    {
        public BakimRepository(DatabaseContext context): base(context) { }
    }
}
