using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using Seats4Me.DataAccess.Context;

namespace Seats4Me.DataAccess.Repositories
{
    public class BaseRepository
    {
        protected readonly Seats4MeContext Context;

        protected BaseRepository(Seats4MeContext context)
        {
            Context = context;
        }
    }
}
