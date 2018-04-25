using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seats4Me.DataAccess.Context;
using Seats4Me.DataAccess.Interfaces;
using Seats4Me.Model.Result;

namespace Seats4Me.DataAccess.Repositories
{
    public class ShowRepository : BaseRepository, IShowRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public ShowRepository(Seats4MeContext context) : base(context)
        {
        }

        /// <summary>
        /// Get a show by Id
        /// </summary>
        /// <param name="showId"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<Show> GetShowAsync(int showId)
        {
            return await Context.Shows.FindAsync(showId);
        }
    }
}
