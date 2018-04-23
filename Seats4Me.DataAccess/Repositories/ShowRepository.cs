using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seats4Me.DataAccess.Context;
using Seats4Me.DataAccess.Interfaces;
using Seats4Me.Model.Result;

namespace Seats4Me.DataAccess.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private readonly Seats4MeContext _context;

        public ShowRepository(Seats4MeContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task<Show> GetShowAsync(int showId)
        {
            return await _context.Shows.FindAsync(showId);
        }
    }
}
