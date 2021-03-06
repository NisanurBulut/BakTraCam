﻿using BakTraCam.Core.DataAccess.Context;
using BakTraCam.Core.DataAccess.Repositores.Base;
using BakTraCam.Core.Entity;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace BakTraCam.Core.DataAccess.Repositores
{
    public sealed class KullaniciRepository : BaseRepository<KullaniciEntity>, IKullaniciRepository
    {
        public KullaniciRepository(DatabaseContext context): base(context) { }
    }
}
